using Microsoft.AspNetCore.Components;
using Cryptocash.Application.Dto;

namespace Cryptocash.Ui.Generated.Component
{
#nullable enable

    public class UiViewEntityZeroOrManyLandLordBase : ComponentBase
    {
        #region Declarations

        [Parameter]
        public List<LandLordDto>? LandLordList { get; set; }

        #endregion

        public string DisplayLandLordList
        {
            get
            {
                string ReturnLandLordList = String.Empty;

                if (LandLordList != null
                    && LandLordList.Count > 0)
                {
                    bool Fresh = true;
                    foreach (LandLordDto CurrentlandLord in LandLordList)
                    {
                        if (!String.IsNullOrWhiteSpace(CurrentlandLord.Name))
                        {
                            if (!Fresh)
                            {
                                ReturnLandLordList += ", ";
                            }
                            ReturnLandLordList += CurrentlandLord.Name;

                            Fresh = false;
                        }                        
                    }
                }

                return ReturnLandLordList;
            }
        }
    }
}