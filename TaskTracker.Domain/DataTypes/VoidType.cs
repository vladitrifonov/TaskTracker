namespace TaskTracker.Domain.DataTypes
{
    /// <summary>
    /// Represents a void type, since System.Void is not a valid return type in C#.  
    /// </summary>  
    public readonly struct VoidType
    {
        public static readonly VoidType Instance = new VoidType();
    }    
}
