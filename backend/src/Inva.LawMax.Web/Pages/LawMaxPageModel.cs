using Inva.LawMax.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Inva.LawMax.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class LawMaxPageModel : AbpPageModel
{
    protected LawMaxPageModel()
    {
        LocalizationResourceType = typeof(LawMaxResource);
    }
}
