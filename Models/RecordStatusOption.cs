using System.ComponentModel.DataAnnotations;

namespace Medhavi_MVC.Models
{
    public enum RecordStatusOption
    {
        #region stores in table as well as log in log table
        [Display(Name = "Newly Created")]
        NewlyCreated = 0,

        [Display(Name = "Verified")]
        Verified = 1,

        [Display(Name = "Rejected")]
        Rejected = 2,
        #endregion

        #region stores only in log
        [Display(Name = "Deleted [Unverified Data]")]
        Deleted = 3,

        [Display(Name = "Modify Request [Verified Data]")]
        ModifyRequest_VerifiedData = 4,

        [Display(Name = "Delete Request [Verified Data]")]
        DeleteRequest_VerifiedData = 5,

        [Display(Name = "Rejected [Verified Data]")]
        Rejected_VerifiedData = 6,

        [Display(Name = "Deleted [Verified Data]")]  //stores in log as well as in table with status (soft deleted)
        Deleted_VerifiedData = 7,
        #endregion
    }
}
