using Microsoft.AspNetCore.Components;
using MudBlazor;
using Cryptocash.Ui.Generated.Data.Helper;
using Cryptocash.Ui.Generated.Data.ApiSetting;
using Cryptocash.Ui.Generated.Data.Enum;
using Microsoft.AspNetCore.Components.Web;
using Cryptocash.Ui.Generated.Data.Generic;
using MassTransit.Serialization.JsonConverters;
using System.Security.Principal;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using Cryptocash.Ui.Generated.Data.Generic.Service;
using Cryptocash.Application.Dto;

namespace Cryptocash.Ui.Generated.Pages.Generic
{
    /// <summary>
    /// PageBase Class to handle List Entity related pages note: T is used to reduce the amount of generator code required
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ListEntityPageBase<T, CreateT> : ComponentBase
    {
        #nullable enable

        #region Declarations

        /// <summary>
        /// Property GlobalData used to handle global data between parent and child components
        /// </summary>
        [CascadingParameter]
        public GlobalData? GlobalData { get; set; }

        // <summary>
        /// Property CurrentApiUiService used for selecting default Api to display
        /// </summary>
        public ApiUiService? CurrentApiUiService { get; set; }

        /// <summary>
        /// Property IsLoading used to handle Ui main loading panel
        /// </summary>
        public bool IsLoading = false;

        /// <summary>
        /// Property CurrentEntityName used to define which Api currently displaying
        /// </summary>
        public string CurrentEntityName = typeof(T).Name[..^3]; //remove word 'Dto' from end

        /// <summary>
        /// Property IsDataGridLoading used to handle Ui datagrid loading panel
        /// </summary>
        public bool IsDataGridLoading = false;

        /// <summary>
        /// Property PreviousAPiQuery used as flag to avoid multiple calls to Api to refresh data
        /// </summary>
        private string PreviousAPiQuery = string.Empty;

        /// <summary>
        /// Property IsOpenSearchFilterDrawer flag used to control search drawer panel hidden or displayed state
        /// </summary>
        public bool IsOpenSearchFilterDrawer = false;

        /// <summary>
        /// Property IsOpenViewDrawer flag used to control view column drawer panel hidden or displayed state
        /// </summary>
        public bool IsOpenViewDrawer = false;

        /// <summary>
        /// Property IsOpenDeleteEntityConfirmation flag used to control Delete Entity confirmation dialog
        /// </summary>
        public bool IsOpenDeleteEntityConfirmation = false;

        /// <summary>
        /// Property IsDeleteEntityProcessing flag used to control display awaiting async process to complete
        /// </summary>
        public bool IsDeleteEntityProcessing = false;

        /// <summary>
        /// Property CurrentDeleteEntityId used to store the current entity Id to delete
        /// </summary>
        public string CurrentDeleteEntityId = string.Empty;

        /// <summary>
        /// Property ApiDeleteEtag used to reference Api Entity when deleting
        /// </summary>
        public System.Guid? CurrentDeleteEtag { get; set; } = null;

        /// <summary>
        /// Property SearchMainValue used as main binding source for Ui text search input control
        /// </summary>
        public string SearchMainValue { get; set; } = string.Empty;

        /// <summary>
        /// Property AddDialogOptions to define dialog css and keyboard options
        /// </summary>
        public DialogOptions AddDialogOptions = new()
        {
            FullWidth = true,
            ClassBackground = "custom-dialog",
            DisableBackdropClick = true,
            MaxWidth = MaxWidth.ExtraLarge
        };

        /// <summary>
        /// Property AddDialogOptions to define dialog css and keyboard options
        /// </summary>
        public DialogOptions DeleteDialogOptions = new()
        {
            FullWidth = true,
            ClassBackground = "custom-dialog",
            DisableBackdropClick = true
        };

        /// <summary>
        /// Property AddEntityForm used to reference Add Antity Form in Ui
        /// </summary>
        public MudForm? AddEntityForm { get; set; }

        /// <summary>
        /// Property IsVisibleAddDialog to handle Add Entity dialog visibility
        /// </summary>
        public bool IsVisibleAddEntityDialog = false;

        /// <summary>
        /// Property CurrentAddEntity used as a temporary storage whilst adding entity to api
        /// </summary>
        public CreateT? CurrentAddEntity { get; set; } = default;

        /// <summary>
        /// Property AddEntityValidateSuccess used to ensure form passed dataannotation validation before proceeding
        /// </summary>
        public bool AddEntityValidateSuccess { get; set; } = false;

        /// <summary>
        /// Property IsAddEntityProcessing used to display loading status whilst Add request is processing
        /// </summary>
        public bool IsAddEntityProcessing { get; set; } = false;

        /// <summary>
        /// Property CountryEntityData used to store Country list data in preparation for seletion
        /// </summary>
        public EntityData<CountryDto>? CountryEntityData { get; set; }

        /// <summary>
        /// Property LandLordEntityData used to store LandLord list data in preparation for seletion
        /// </summary>
        public EntityData<LandLordDto>? LandLordEntityData { get; set; }

        #endregion

        #region Generator Related

        /// <summary>
        /// Property CurrentPageLink used to define which Api currently displaying
        /// </summary>
        public string CurrentPageLink = typeof(T).Name[..^6]; //remove word 'Entity' from end

        /// <summary>
        /// Property ApiEntityService used to define which default settings and Api data access to currently use
        /// </summary>
        private IEntityService? ApiEntityService { get; set; } = EntityHelper.GetEntityService<T>();

        /// <summary>
        /// Property ApiEntityData used as main storage for Api result data
        /// </summary>
        private EntityData<T>? ApiEntityData = null;

        /// <summary>
        /// Property PagedData used as main data source for Ui datagrid
        /// </summary>
        public IEnumerable<T>? PagedData = null;

        /// <summary>
        /// Property MudTable used as main reference to Ui datagrid
        /// </summary>
        public MudTable<T>? DataGridTable;

        /// <summary>
        /// Method to refresh Ui datagrid on search, order, paging and view events
        /// </summary>
        /// <param name="State"></param>
        /// <returns>Task<TableData<ApiEntity>></returns>
        public async Task<TableData<T>> ServerReload(TableState State)
        {
            if (IsPagingPopulated)
            {
                CurrentApiUiService!.Paging!.SetCurrentPage(State.Page);
                CurrentApiUiService!.Paging!.SetCurrentPageSize(State.PageSize);
            }

            if (CurrentEntityName == "VendingMachine") //TODO just VendingMachine for now
            {
                await GetApiEntityData();
            }

            return new TableData<T>() { TotalItems = Convert.ToInt32(ApiEntityData?.EntityTotal), Items = PagedData };
        }

        /// <summary>
        /// Method to handle data retrieval from Api
        /// NOTE: Will only be fired if query has changed otherwise app could call Api multiple times between page refreshes
        /// </summary>
        /// <returns></returns>
        private async Task GetApiEntityData()
        {
            string CurrentApiQuery = CurrentApiUiService!.ApiGetQuery;

            if (ApiEntityData == null
                || String.IsNullOrEmpty(PreviousAPiQuery)
                || !String.Equals(PreviousAPiQuery, CurrentApiQuery, StringComparison.OrdinalIgnoreCase))
            {
                ApiEntityData = await EntityDataService<T>.GetAsyncEntityData(CurrentApiUiService);

                PreviousAPiQuery = CurrentApiQuery;

                if (IsPagingPopulated)
                {
                    CurrentApiUiService!.Paging!.SetEntityTotal(ApiEntityData?.EntityTotal);
                }

                PagedData = ApiEntityData?.EntityList;
            }
        }

        /// <summary>
        /// Method to send add entity data to Api
        /// </summary>
        /// <returns></returns>
        private async Task CreateApiEntityData()
        {
            if (CurrentAddEntity != null)
            {
                //TODO Commented out for now - but need to discuss Validate pre Creation POST
                //var CreateEntityValidate = CurrentAddEntity!.Validate();
                //if (CreateEntityValidate == null && CreateEntityValidate.Count() > 0)
                //{
                //    var ErrorMessage = new StringBuilder().AppendLine("VendingMachineService.GetCreateEntityQuery: Validation Errors: ");

                //    foreach (var item in CreateEntityValidate)
                //    {
                //        ErrorMessage.AppendLine(item.Key + ":" + item.Value);
                //    }

                //    throw new ArgumentException(ErrorMessage.ToString(), nameof(T));
                //}

                var jsonOptions = new JsonSerializerOptions();
                jsonOptions.Converters.Add(new JsonStringEnumConverter());

                CurrentApiUiService!.ApiCreateData = JsonSerializer.Serialize(CurrentAddEntity, jsonOptions);

                await EntityDataService<T>.CreateAsyncEntityData(CurrentApiUiService);
            }
        }

        /// <summary>
        /// Method to send add entity data to Api
        /// </summary>
        /// <returns></returns>
        private async Task DeleteApiEntityData()
        {
            await EntityDataService<T>.DeleteAsyncEntityData(CurrentApiUiService);            
        }

        #endregion

        #region Main Page Functions

        /// <summary>
        /// Initialise method to initally setup page and default data
        /// </summary>
        /// <returns></returns>
        protected override async Task OnInitializedAsync()
        {
            IsLoading = true;
            IsDataGridLoading = false;

            if (ApiEntityService != null)
            {
                CurrentApiUiService = ApiEntityService.IntialiseApiUiService();
            }

            UpdateHeaderApiName();

            CurrentApiUiService?.ResetAllSearchFilterList();
            CurrentApiUiService?.ResetOrderList();
            ResetViewList();
            ResetAddEntity();
            await GetAllCountries();
            await GetAllLandLords();

            if (CurrentEntityName == "VendingMachine") //TODO just VendingMachine for now
            {
                await GetApiEntityData();
            }            

            IsLoading = false;
        }

        /// <summary>
        /// Method to update the current Api definition globally in this case to change the header title to current Api name
        /// </summary>
        private void UpdateHeaderApiName()
        {
            if (GlobalData != null)
            {
                GlobalData.CurrentDomainEntity = CurrentEntityName;
                GlobalData.ValuesChanged?.Invoke();
            }
        }

        #endregion

        #region SearchFilter

        /// <summary>
        /// Property to check search filter populated used to avoid nulls
        /// </summary>
        public bool IsSearchFilterPopulated
        {
            get
            {
                return CurrentApiUiService != null
                    && CurrentApiUiService.SearchFilterList != null
                    && CurrentApiUiService.SearchFilterList.Any();
            }
        }

        /// <summary>
        /// Method to perform search and query Api - note task bool is to enforce datagrid refresh
        /// </summary>
        /// <returns>Task<bool></returns>
        public async Task Search()
        {
            IsDataGridLoading = true;

            IsOpenSearchFilterDrawer = false;

            if (IsPagingPopulated)
            {
                CurrentApiUiService!.Paging!.ResetPaging();
            }

            if (IsSearchFilterPopulated)
            {
                CurrentApiUiService!.ResetFilterSearchFilterList();
                CurrentApiUiService!.UpdateMainSearchFilterList(SearchMainValue);
                CurrentApiUiService!.UpdateFilterSearchFilterList();
            }

            if (DataGridTable != null)
            {
                await DataGridTable!.ReloadServerData();
            }

            IsDataGridLoading = false;
        }

        /// <summary>
        /// Method to handle KeyUp press on textbox so that search can be performed without clicking button
        /// </summary>
        public async void SearchEnterSubmit(KeyboardEventArgs CurrentEvent)
        {
            if (CurrentEvent != null && (CurrentEvent.Code == "Enter" || CurrentEvent.Code == "NumpadEnter"))
            {
                await Search();
            }
        }

        /// <summary>
        /// Method to open Search Filter drawer panel
        /// </summary>
        /// <param name="Open"></param>
        public void OpenSearchFilterDrawer(bool Open)
        {
            IsOpenSearchFilterDrawer = Open;
        }

        /// <summary>
        /// Method to apply the search filters set on the search filter Ui drawer panel and request Api search query
        /// </summary>
        /// <returns>Task<bool></returns>
        public async Task ApplySearchFilterList()
        {
            IsDataGridLoading = true;

            IsOpenSearchFilterDrawer = false;

            if (IsPagingPopulated)
            {
                CurrentApiUiService!.Paging!.ResetPaging();
            }

            if (IsSearchFilterPopulated)
            {
                SearchMainValue = string.Empty;
                CurrentApiUiService!.ResetMainSearchFilterList();
                CurrentApiUiService!.UpdateMainSearchFilterList(SearchMainValue);
                CurrentApiUiService!.UpdateFilterSearchFilterList();
            }

            if (DataGridTable != null)
            {
                await DataGridTable!.ReloadServerData();
            }

            IsDataGridLoading = false;
        }

        /// <summary>
        /// Method to handle clear button and update the current filter popup related search filter to empty
        /// </summary>
        /// <param name="CurrentValue"></param>
        /// <param name="CurrentFilter"></param>
        public void ClearSearchFilter(MouseEventArgs CurrentValue, SearchFilter CurrentFilter)
        {
            if (CurrentFilter != null
                && CurrentValue != null
                && !string.IsNullOrWhiteSpace(CurrentFilter.PropertyName)
                && IsSearchFilterPopulated)
            {
                CurrentApiUiService!.UpdateSearchFilter(String.Empty, CurrentFilter);
            }
        }

        /// <summary>
        /// Method to handle clear button and update the current main search textbox related search filters to empty
        /// </summary>
        /// <param name="CurrentValue"></param>
        /// <param name="CurrentFilter"></param>
        public void ClearMainSearchFilterList()
        {
            if (IsSearchFilterPopulated)
            {
                SearchMainValue = string.Empty;
                CurrentApiUiService!.ResetMainSearchFilterList();
            }
        }

        #endregion

        #region Order

        /// <summary>
        /// Property to check order populated used to avoid nulls
        /// </summary>
        public bool IsOrderPopulated
        {
            get
            {
                return CurrentApiUiService != null
                     && CurrentApiUiService.OrderList != null
                     && CurrentApiUiService.OrderList.Any();
            }
        }

        /// <summary>
        /// Method to update the order to the new value
        /// </summary>
        /// <param name="OrderTypeValue"></param>
        /// <param name="PropertyName"></param>
        /// <returns>Task<bool></returns>
        public async Task UpdateOrder(string OrderTypeValue, string PropertyName)
        {
            IsDataGridLoading = true;

            if (!string.IsNullOrWhiteSpace(PropertyName)
                && IsOrderPopulated)
            {
                var Index = CurrentApiUiService!.OrderList!.FindIndex(Order =>
                Order.PropertyName != null
                && Order.PropertyName.Equals(PropertyName, StringComparison.OrdinalIgnoreCase));
                if (Index > -1)
                {
                    SortOrderDirection OrderType = SortOrderDirection.None;
                    switch (OrderTypeValue.ToLower())
                    {
                        case "ascending":
                            OrderType = SortOrderDirection.Ascending;
                            break;
                        case "descending":
                            OrderType = SortOrderDirection.Descending;
                            break;
                    }
                    CurrentApiUiService?.OrderList?[Convert.ToInt32(Index)].UpdateCurrentOrderDirection(OrderType);
                }

                CurrentApiUiService!.SwitchOffOtherOrderList(PropertyName);

                if (DataGridTable != null)
                {
#pragma warning disable BL0005 // Component parameter should not be set outside of its component. 
                    DataGridTable!.CurrentPage = 0; //only reliable way to reset page on reorder
#pragma warning restore BL0005 // Component parameter should not be set outside of its component.
                    await DataGridTable!.ReloadServerData();
                }
            }

            IsDataGridLoading = false;
        }

        /// <summary>
        /// Method to return the current MudBlazor.SortDirection against a property
        /// </summary>
        /// <param name="PropertyName"></param>
        /// <returns>MudBlazor.SortDirection</returns>
        public SortDirection GetPropertyMudSortDirection(string PropertyName)
        {
            SortDirection GetSortDirection = SortDirection.None;

            if (IsOrderPopulated)
            {
                switch (CurrentApiUiService!.GetCurrentOrderType(PropertyName))
                {
                    case SortOrderDirection.Ascending:
                        GetSortDirection = SortDirection.Ascending;
                        break;
                    case SortOrderDirection.Descending:
                        GetSortDirection = SortDirection.Descending;
                        break;
                }
            }

            return GetSortDirection;
        }

        #endregion

        #region View

        /// <summary>
        /// Property to check view populated used to avoid nulls
        /// </summary>
        public bool IsViewPopulated
        {
            get
            {
                return CurrentApiUiService != null
                     && CurrentApiUiService.ViewList != null
                     && CurrentApiUiService.ViewList.Any();
            }
        }

        /// <summary>
        /// Method to open view drawer panel
        /// </summary>
        /// <param name="Open"></param>
        public void OpenViewDrawer(bool Open)
        {
            IsOpenViewDrawer = Open;
        }

        /// <summary>
        /// Method to apply view settings to the Ui datagrid
        /// </summary>
        public void ApplyViewList()
        {
            IsOpenViewDrawer = false;

            if (IsViewPopulated)
            {
                CurrentApiUiService!.ApplyShowInSearchList();
            }
        }

        /// <summary>
        /// Method to reset view on the Ui datagrid to default values
        /// </summary>
        public void ResetViewList()
        {
            IsOpenViewDrawer = false;

            if (IsViewPopulated)
            {
                CurrentApiUiService!.ResetShowInSearchList();
            }
        }

        #endregion

        #region Paging

        /// <summary>
        /// Property to check paging populated used to avoid nulls
        /// </summary>
        public bool IsPagingPopulated
        {
            get
            {
                return CurrentApiUiService != null
                    && CurrentApiUiService.Paging != null;
            }
        }

        #endregion

        #region Add

        /// <summary>
        /// Method to Reset CurrentAddEntity to a new class of T ready to be populated by Add Item Dialog panel on Ui
        /// </summary>
        private void ResetAddEntity()
        {
            CurrentAddEntity = (CreateT?)Activator.CreateInstance(typeof(CreateT));
        }

        /// <summary>
        /// Method to open Add Entity dialog
        /// </summary>
        public void AddEntityOpenDialog()
        {
            ResetAddEntity();
            IsVisibleAddEntityDialog = true;
        }

        /// <summary>
        /// Method to close Add Entity dialog
        /// </summary>
        public void AddEntityCloseDialog()
        {
            IsVisibleAddEntityDialog = false;
        }

        /// <summary>
        /// Method to Create AddEntity and send to Api
        /// </summary>
        /// <returns>Task</returns>
        public async Task AddEntitySubmit()
        {
            if (AddEntityForm != null)
            {
                await AddEntityForm.Validate();

                if (AddEntityForm.IsValid)
                {
                    IsAddEntityProcessing = true;

                    AddEntityValidateSuccess = true;

                    var test = CurrentAddEntity; //TODO remove later

                    await CreateApiEntityData();

                    CurrentApiUiService?.ResetAllSearchFilterList();
                    CurrentApiUiService?.ResetOrderList();
                    ResetViewList();
                    ResetAddEntity();

                    ShowSuccessSnackbar("Entity Added Successfully");

                    PreviousAPiQuery = String.Empty;
                    if (DataGridTable != null)
                    {
                        await DataGridTable!.ReloadServerData();
                    }

                    IsVisibleAddEntityDialog = false;

                    IsAddEntityProcessing = false;
                }
            }
        }

        #endregion

        #region Delete

        /// <summary>
        /// Method to Reset CurrentDeleteEntityId
        /// </summary>
        private void ResetDeleteEntity()
        {
            CurrentDeleteEntityId = string.Empty;
            CurrentDeleteEtag = null;
        }

        /// <summary>
        /// Method to open Delete Entity confirmation
        /// </summary>
        public void DeleteEntitySelect(string EntityId, System.Guid EntityEtag)
        {
            CurrentDeleteEntityId = EntityId;
            CurrentDeleteEtag = EntityEtag;
            DeleteEntityOpenConfirmation();
        }

        /// <summary>
        /// Method to open Delete Entity confirmation
        /// </summary>
        public void DeleteEntityOpenConfirmation()
        {
            IsOpenDeleteEntityConfirmation = true;
        }

        /// <summary>
        /// Method to close Delete Entity confirmation
        /// </summary>
        public void DeleteEntityCloseConfirmation()
        {
            IsOpenDeleteEntityConfirmation = false;
        }

        /// <summary>
        /// Method to Delete Entity within Api
        /// </summary>
        /// <returns>Task</returns>
        public async Task DeleteEntitySubmit()
        {
            if (!String.IsNullOrWhiteSpace(CurrentDeleteEntityId)
                && CurrentApiUiService != null)
            {
                IsDeleteEntityProcessing = true;

                CurrentApiUiService!.ApiDeleteQueryData = CurrentDeleteEntityId;
                CurrentApiUiService!.ApiDeleteEtag = CurrentDeleteEtag;

                await DeleteApiEntityData();

                CurrentApiUiService!.ResetAllSearchFilterList();
                CurrentApiUiService!.ResetOrderList();
                ResetViewList();
                ResetDeleteEntity();

                ShowSuccessSnackbar("Vending machine deleted successfully");

                PreviousAPiQuery = String.Empty;
                if (DataGridTable != null)
                {
                    await DataGridTable!.ReloadServerData();
                }

                IsOpenDeleteEntityConfirmation = false;
            }

            IsDeleteEntityProcessing = false;
        }

        #endregion

        #region Snackbar Alert

        [Inject]
        public ISnackbar? Snackbar { get; set; }

        /// <summary>
        /// Method to show disappearing snackbar alert message to Ui
        /// </summary>
        /// <param name="Message"></param>
        public void ShowSuccessSnackbar(string Message)
        {
            Snackbar!.Configuration.NewestOnTop = true;
            Snackbar!.Configuration.PreventDuplicates = true;
            Snackbar!.Configuration.PositionClass = Defaults.Classes.Position.BottomCenter;

            Snackbar!.Add(Message,
                Severity.Success,
                config =>
                {
                    config.ShowCloseIcon = true;
                    config.DuplicatesBehavior = SnackbarDuplicatesBehavior.Prevent;
                    config.VisibleStateDuration = 4000;
                    config.HideTransitionDuration = 500;
                    config.ShowTransitionDuration = 500;
                    config.SnackbarVariant = Variant.Filled;
                });
        }

        #endregion

        #region Selection List Data

        /// <summary>
        /// Method to get all Countries in preparation to populate selection lists
        /// </summary>
        /// <returns></returns>
        protected async Task GetAllCountries()
        {
            ApiUiService CountryApiService = new CountryService().IntialiseApiUiService();
            CountryEntityData = await EntityDataService<CountryDto>.GetAsyncRecursivePagedEntityData(CountryApiService);

            return;
        }

        /// <summary>
        /// Method to get all LandLords in preparation to populate selection lists
        /// </summary>
        /// <returns></returns>
        protected async Task GetAllLandLords()
        {
            ApiUiService LandLordApiService = new LandLordService().IntialiseApiUiService();
            LandLordEntityData = await EntityDataService<LandLordDto>.GetAsyncRecursivePagedEntityData(LandLordApiService);

            return;
        }

        #endregion
    }
}