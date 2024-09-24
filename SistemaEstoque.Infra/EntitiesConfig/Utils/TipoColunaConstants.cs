namespace SistemaEstoque.Infra.EntitiesConfig.Utils;

public static class TipoColunaConstants
{
    private static readonly string TamanhoVarchar = "150";
    
    public static readonly string Int      = "int";
    public static readonly string Double   = "double";
    public static readonly string Decimal  = "decimal";
    public static readonly string Boolean = "boolean";
    public static readonly string VarcharDefault = $"varchar({TamanhoVarchar})";
    public static readonly string VarcharCpfCnpj = "varchar(14)";
    public static readonly string VarcharCelular = "varchar(15)";
    public static readonly string VarcharCep = "varchar(8)";
    public static readonly string Varchar    = "varchar"; // precisa usar um string format para adicionar quantidade
    public static readonly string Text = "text";
    public static readonly string Jsonb = "jsonb";
    
    public static readonly string TimestampWithTimeZone = "TIMESTAMP WITH TIME ZONE";
}