using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Helpers;
using CERP.App;
using CERP.App.Helpers;
using CERP.AppServices.Setup.Lookup;
using CERP.Web.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;

namespace CERP.Web.Areas.Setup.Codes
{
    public class ListModel : CERPPageModel
    {
        public ListModel(DictionaryValueAppService dictionaryValueAppService, IGuidGenerator guidGenerator, DictionaryValueTypeAppService dictionaryValueTypeAppService)
        {
            this.dictionaryValueAppService = dictionaryValueAppService;
            this.guidGenerator = guidGenerator;
            this.dictionaryValueTypeAppService = dictionaryValueTypeAppService;
        }

        public IGuidGenerator guidGenerator { get; set; }
        public DictionaryValueAppService dictionaryValueAppService { get; set; }
        public DictionaryValueTypeAppService dictionaryValueTypeAppService { get; set; }

        public string[] GetModulesDS()
        {
            List<string> res = new List<string>();

            var values = EnumExtensions.GetDescriptions(typeof(ValueTypeModules));
            var curValues = dictionaryValueTypeAppService.Repository.Select(x => x.ValueTypeFor).ToArray();

            for (int i = 0; i < values.Length; i++)
            {
                if (!curValues.Any(x => x.GetDescription() == values[i]))
                    res.Add(values[i]);
            }

            return res.ToArray();
        }
        public JsonResult OnGetModulesTypes()
        {
            JsonResult result = new JsonResult(GetModulesDS());
            return result;
        }
        public void OnGet()
        {
        }
        //public IActionResult OnPost()
        //{
        //    return Content("fds");
        //}
        public async Task<IActionResult> OnPostNewDicValue(DictionaryValue_Dto dicValue, Guid valueTypeId)
        {
            dicValue.Id = guidGenerator.Create();

            dicValue.ValueType = null;
            try
            {
                DictionaryValueType valueType = dictionaryValueTypeAppService.Repository.WithDetails(x => x.Values).First(x => x.Id == valueTypeId);
                int curCount = valueType.Values.Count;

                dicValue.ValueTypeId = valueTypeId;
                string paddedCode = $"{valueType.ValueTypeCode}{(curCount + 1).ToString().PadLeft(3, '0')}";
                int curRetryIndex = 2;
                while (dictionaryValueAppService.Repository.Any(x => x.Key == paddedCode))
                {
                    paddedCode = $"{valueType.ValueTypeCode}{(curCount + curRetryIndex).ToString().PadLeft(3, '0')}";
                    curRetryIndex++;
                }
                dicValue.Key = $"{paddedCode}";

                //valueType.Values.Add(ObjectMapper.Map<DictionaryValue_Dto, DictionaryValue>(dicValue));
                
                var value = await dictionaryValueAppService.CreateAsync(dicValue);
                value.ValueType = ObjectMapper.Map<DictionaryValueType, DictionaryValueType_Dto>(valueType);
                return new OkObjectResult(value);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(500);
            }
        }

        public async Task<IActionResult> OnPostDicValue(DictionaryValue_Dto dicValue)
        {
            dicValue.ValueType = null;
            try
            {
                var value = await dictionaryValueAppService.UpdateAsync(dicValue.Id, dicValue);
                return new OkResult();
            }
            catch(Exception ex)
            {
                return new StatusCodeResult(500);
            }
        }
        public async Task<IActionResult> OnDeleteDicValue(IList<DictionaryValue_Dto> dicValues)
        {
            try
            {
                for (int i = 0; i < dicValues.Count; i++)
                {
                    DictionaryValue_Dto value = (DictionaryValue_Dto)dicValues[i];
                    value.ValueType = null;
                    await dictionaryValueAppService.DeleteAsync(value.Id);
                }
                return new OkResult();
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(500);
            }
        }

        public JsonResult OnGetUpdateGrid(string valueTypeCode)
        {
            var Values = dictionaryValueAppService.Repository.WithDetails(x => x.ValueType).Where(x => x.ValueType.ValueTypeCode == valueTypeCode).OrderBy(x => x.Key).ToList();
            ViewData["CurDicValueGridDS"] = Values;
            return new JsonResult(Values);
        }

        public JsonResult OnGetUpdateVTGrid()
        {
            var Values = ObjectMapper.Map<List<DictionaryValueType>, List<DictionaryValueType_Dto>>(dictionaryValueTypeAppService.Repository.OrderBy(x => x.ValueTypeCode).ToList());
            ViewData["CurDicValueTypeGridDS"] = Values;
            return new JsonResult(Values);
        }

        public async Task<IActionResult> OnPostNewDicVT(DictionaryValueType_Dto dicValueType)
        {
            dicValueType.Id = guidGenerator.Create();

            try
            {
                int valueTypesCount = dictionaryValueTypeAppService.Repository.Count();

                string paddedCode = (valueTypesCount + 1).ToString().PadLeft(2, '0');
                int curRetryIndex = 2; 
                while (dictionaryValueTypeAppService.Repository.Any(x => x.ValueTypeCode == paddedCode))
                {
                    paddedCode = (valueTypesCount + curRetryIndex).ToString().PadLeft(2, '0');
                    curRetryIndex++;
                }
                dicValueType.ValueTypeCode = $"{paddedCode}";

                //valueType.Values.Add(ObjectMapper.Map<DictionaryValue_Dto, DictionaryValue>(dicValue));

                var value = await dictionaryValueTypeAppService.CreateAsync(dicValueType);
                return new OkObjectResult(value);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(500);
            }
        }

        public async Task<IActionResult> OnPostDicVT(DictionaryValueType_Dto dicValueType)
        {
            try
            {
                var entity = dictionaryValueTypeAppService.Repository.First(x => x.Id == dicValueType.Id);
                entity.ValueTypeName = dicValueType.ValueTypeName;
                entity.ValueTypeNameLocalizationKey = dicValueType.ValueTypeNameLocalizationKey;
                var value = await dictionaryValueTypeAppService.Repository.UpdateAsync(entity);
                return new OkResult();
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(500);
            }
        }
        public async Task<IActionResult> OnDeleteDicVT(IList<DictionaryValueType_Dto> dicValueTypes)
        {
            try
            {
                for (int i = 0; i < dicValueTypes.Count; i++)
                {
                    DictionaryValueType_Dto value = (DictionaryValueType_Dto)dicValueTypes[i];
                    await dictionaryValueTypeAppService.DeleteAsync(value.Id);
                }
                return new OkResult();
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(500);
            }
        }
    }
}
