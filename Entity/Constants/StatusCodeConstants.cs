namespace Entity.Constants;

public static class StatusCodeConstants
{
    public const int InternalServerError = 500;
    public const int BadRequest = 400;
    public const int NotFound = 404;
    public const int Unauthorized = 401;
    public const int Forbidden = 403;
    public const int Created = 201;
    public const int Ok = 200;

}
public static class Validations
{
    public const int MaximumNumberOfDegrees = 3;
    public const int NameMaxLength = 250;
    public const int MinAge = 0;
    public const int MaxAge = 150;
    public const int NameDegreeMaxLength = 250;
    public const int IssuedByMaxLength = 550;
}