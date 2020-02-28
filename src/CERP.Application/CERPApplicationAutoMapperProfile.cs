using AutoMapper;
using CERP.FM;
using CERP.FM.COA;
using CERP.FM.COA.DTOs;
using CERP.FM.COA.UV_DTOs;
using CERP.FM.DTOs;
using CERP.FM.UV_DTOs;

namespace CERP
{
    public class CERPApplicationAutoMapperProfile : Profile
    {
        public CERPApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */

            CreateMap<COA_Account, COA_Account_Dto>();
            CreateMap<COA_Account_UV_Dto, COA_Account>();

            CreateMap<COA_AccountSubCategory, COA_AccountSubCategory_Dto>();
            CreateMap<COA_AccountSubCategory_UV_Dto, COA_AccountSubCategory>();

            CreateMap<COA_HeadAccount, COA_HeadAccount_Dto>();
            CreateMap<COA_HeadAccount_UV_Dto, COA_HeadAccount>();

            CreateMap<Company, Company_Dto>();
            CreateMap<Company_UV_Dto, Company>();

            CreateMap<Branch, Branch_Dto>();
            CreateMap<Branch_UV_Dto, Branch>();

            CreateMap<COA_SubLedgerRequirement, COA_SubLedgerRequirement_Dto>();
            CreateMap<COA_SubLedgerRequirement_UV_Dto, COA_SubLedgerRequirement>();
        }
    }
}
