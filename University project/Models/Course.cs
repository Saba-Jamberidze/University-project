namespace University_project.Models;

/// <summary>კურსი (ჯგუფი) თარიღებითა და ლექტორით.</summary>.
internal class Course
{
    //Id|Name|Description|DurationMonths|StartDate|TeacherId

    public Guid Id { get; init; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int DurationMonths { get; set; }
    public DateOnly StartDate { get; set; }
    public Guid TeacherId { get; set; }

    /// <summary>კურსის დასრულების თარიღი (დაითვლება დაწყებისა და ხანგრძლივობიდან).</summary>
    public DateOnly EndDate => StartDate.AddMonths(DurationMonths);

    /// <summary>კურსი აქტიურია, თუ დღეს მისი დაწყებისა და დასრულების თარიღებს შორისაა.</summary>
    public bool IsActive
    {
        get
        {
            var today = DateOnly.FromDateTime(DateTime.Now);
            return today >= StartDate && today <= EndDate;
        }
    }
}