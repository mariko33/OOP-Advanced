using SOLID_Exercise.Models.Enums;

namespace SOLID_Exercise.Models.Contracts
{
    public interface IAppender
    {
        ILayout Layout { get; }
        
        ErrorLevel Level { get; }

        void Append(IError error);
    }
}