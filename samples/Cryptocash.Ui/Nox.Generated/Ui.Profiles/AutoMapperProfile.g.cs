using AutoMapper;
using Nox.Ui.Blazor.Lib.Models.NoxTypes;

using Cryptocash.Application.Dto;
using Cryptocash.Ui.Models;

namespace Cryptocash.Ui.Profiles;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        //Compound Nox Types
        CreateMap<StreetAddressDto, StreetAddressModel>().ReverseMap();
        CreateMap<FileDto, FileModel>().ReverseMap();
        CreateMap<TranslatedTextDto, TranslatedTextModel>().ReverseMap();
        CreateMap<VatNumberDto, VatNumberModel>().ReverseMap();
        CreateMap<PasswordDto, PasswordModel>().ReverseMap();
        CreateMap<EntityIdDto, EntityIdModel>().ReverseMap();
        CreateMap<MoneyDto, MoneyModel>().ReverseMap();
        CreateMap<ImageDto, ImageModel>().ReverseMap();
        CreateMap<HashedTextDto, HashedTextModel>().ReverseMap();
        CreateMap<DateTimeRangeDto, DateTimeRangeModel>().ReverseMap();
        CreateMap<LatLongDto, LatLongModel>().ReverseMap();

        //Entities
        CreateMap<BookingDto, BookingModel>().ReverseMap();
        CreateMap<BookingCreateDto, BookingModel>().ReverseMap();
        CreateMap<BookingUpdateDto, BookingModel>().ReverseMap();
        CreateMap<CommissionDto, CommissionModel>().ReverseMap();
        CreateMap<CommissionCreateDto, CommissionModel>().ReverseMap();
        CreateMap<CommissionUpdateDto, CommissionModel>().ReverseMap();
        CreateMap<CountryDto, CountryModel>().ReverseMap();
        CreateMap<CountryCreateDto, CountryModel>().ReverseMap();
        CreateMap<CountryUpdateDto, CountryModel>().ReverseMap();
        CreateMap<CurrencyDto, CurrencyModel>().ReverseMap();
        CreateMap<CurrencyCreateDto, CurrencyModel>().ReverseMap();
        CreateMap<CurrencyUpdateDto, CurrencyModel>().ReverseMap();
        CreateMap<CustomerDto, CustomerModel>().ReverseMap();
        CreateMap<CustomerCreateDto, CustomerModel>().ReverseMap();
        CreateMap<CustomerUpdateDto, CustomerModel>().ReverseMap();
        CreateMap<PaymentDetailDto, PaymentDetailModel>().ReverseMap();
        CreateMap<PaymentDetailCreateDto, PaymentDetailModel>().ReverseMap();
        CreateMap<PaymentDetailUpdateDto, PaymentDetailModel>().ReverseMap();
        CreateMap<TransactionDto, TransactionModel>().ReverseMap();
        CreateMap<TransactionCreateDto, TransactionModel>().ReverseMap();
        CreateMap<TransactionUpdateDto, TransactionModel>().ReverseMap();
        CreateMap<EmployeeDto, EmployeeModel>().ReverseMap();
        CreateMap<EmployeeCreateDto, EmployeeModel>().ReverseMap();
        CreateMap<EmployeeUpdateDto, EmployeeModel>().ReverseMap();
        CreateMap<LandLordDto, LandLordModel>().ReverseMap();
        CreateMap<LandLordCreateDto, LandLordModel>().ReverseMap();
        CreateMap<LandLordUpdateDto, LandLordModel>().ReverseMap();
        CreateMap<MinimumCashStockDto, MinimumCashStockModel>().ReverseMap();
        CreateMap<MinimumCashStockCreateDto, MinimumCashStockModel>().ReverseMap();
        CreateMap<MinimumCashStockUpdateDto, MinimumCashStockModel>().ReverseMap();
        CreateMap<PaymentProviderDto, PaymentProviderModel>().ReverseMap();
        CreateMap<PaymentProviderCreateDto, PaymentProviderModel>().ReverseMap();
        CreateMap<PaymentProviderUpdateDto, PaymentProviderModel>().ReverseMap();
        CreateMap<VendingMachineDto, VendingMachineModel>().ReverseMap();
        CreateMap<VendingMachineCreateDto, VendingMachineModel>().ReverseMap();
        CreateMap<VendingMachineUpdateDto, VendingMachineModel>().ReverseMap();
        CreateMap<CashStockOrderDto, CashStockOrderModel>().ReverseMap();
        CreateMap<CashStockOrderCreateDto, CashStockOrderModel>().ReverseMap();
        CreateMap<CashStockOrderUpdateDto, CashStockOrderModel>().ReverseMap();
    }
}