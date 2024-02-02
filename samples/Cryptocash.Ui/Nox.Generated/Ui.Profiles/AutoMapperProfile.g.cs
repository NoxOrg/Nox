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
        //CreateMap<StreetAddressDto, StreetAddressModel>().ReverseMap();
        //CreateMap<FileDto, FileModel>().ReverseMap();
        //CreateMap<TranslatedTextDto, TranslatedTextModel>().ReverseMap();
        //CreateMap<VatNumberDto, VatNumberModel>().ReverseMap();
        //CreateMap<PasswordDto, PasswordModel>().ReverseMap();
        //CreateMap<EntityIdDto, EntityIdModel>().ReverseMap();
        //CreateMap<MoneyDto, MoneyModel>().ReverseMap();
        //CreateMap<ImageDto, ImageModel>().ReverseMap();
        //CreateMap<HashedTextDto, HashedTextModel>().ReverseMap();
        //CreateMap<DateTimeRangeDto, DateTimeRangeModel>().ReverseMap();
        //CreateMap<LatLongDto, LatLongModel>().ReverseMap();

        //Entities
        CreateMap<BookingDto, BookingModel>().ReverseMap();
        CreateMap<CommissionDto, CommissionModel>().ReverseMap();
        CreateMap<CountryDto, CountryModel>().ReverseMap();
        CreateMap<CurrencyDto, CurrencyModel>().ReverseMap();
        CreateMap<CustomerDto, CustomerModel>().ReverseMap();
        CreateMap<PaymentDetailDto, PaymentDetailModel>().ReverseMap();
        CreateMap<TransactionDto, TransactionModel>().ReverseMap();
        CreateMap<EmployeeDto, EmployeeModel>().ReverseMap();
        CreateMap<LandLordDto, LandLordModel>().ReverseMap();
        CreateMap<MinimumCashStockDto, MinimumCashStockModel>().ReverseMap();
        CreateMap<PaymentProviderDto, PaymentProviderModel>().ReverseMap();
        CreateMap<VendingMachineDto, VendingMachineModel>().ReverseMap();
        CreateMap<CashStockOrderDto, CashStockOrderModel>().ReverseMap();
    }
}