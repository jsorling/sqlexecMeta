namespace Sorling.SqlExecMeta;

public interface IPrevNxtSqlItem
{
   public string? PreviousId { get; }

   public SqlGroupFlags? PreviousGroup { get; }

   public string? PreviousSchema { get; }

   public string? PreviousName { get; }

   public string CurrentId { get; }

   public string? NextId { get; }

   public SqlGroupFlags? NextGroup { get; }

   public string? NextSchema { get; }

   public string? NextName { get; }
}
