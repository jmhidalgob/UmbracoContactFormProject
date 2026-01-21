using NPoco;
using Umbraco.Cms.Infrastructure.Persistence.DatabaseAnnotations;

namespace UmbracoContactFormProject.Persistence;

[TableName("ContactMessages")]
[PrimaryKey("Id", AutoIncrement = true)]
[ExplicitColumns]
public class ContactMessageSchema
{
    [PrimaryKeyColumn(AutoIncrement = true)]
    [Column("Id")]
    public int Id { get; set; }

    [Column("Name")]
    public string Name { get; set; } = string.Empty;

    [Column("Email")]
    public string Email { get; set; } = string.Empty;

    [Column("Message")]
    [SpecialDbType(SpecialDbTypes.NVARCHARMAX)]
    public string Message { get; set; } = string.Empty;

    [Column("CreateDate")]
    public DateTime CreateDate { get; set; } = DateTime.Now;
}