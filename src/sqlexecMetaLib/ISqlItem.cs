namespace Sorling.SqlExecMeta;

public interface ISqlItem
{
   public int Id { get; }

   public string Name { get; }

   public string SchemaName { get; }

   public string Group { get; }

   public SqlGroupFlags GroupFlag { get; }

   public string DBName { get; }
}
