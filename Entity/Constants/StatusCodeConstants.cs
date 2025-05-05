namespace Entity.Constants;

public static class StatusCodeConstants
{
    public static readonly int InternalServerError = 500;
    public static readonly int BadRequest = 400;
    public static readonly int NotFound = 404;
    public static readonly int Unauthorized = 401;
    public static readonly int Forbidden = 403;
    public static readonly int Created = 201;
    public static readonly int Ok = 200;

}
public static class Validations
{
    public static readonly int MaximumNumberOfDegrees = 3;
    public static readonly int NameMaxLength = 250;
    public static readonly int MinAge = 0;
    public static readonly int MaxAge = 150;
    public static readonly int NameDegreeMaxLength = 250;
    public static readonly int IssuedByMaxLength = 550;
}