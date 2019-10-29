using System;

public static class ErrorHandling
{
    public static void HandleErrorByThrowingException()
    {
        throw new Exception("*** Exception Thrown ***");
    }

    public static int? HandleErrorByReturningNullableType(string input)
    {
        int? result;

        try
        {
            result = Int32.Parse(input);
        }
        catch (Exception)
        {
            result = null;
        }

        return result;
    }

    public static bool HandleErrorWithOutParam(string input, out int result)
    {
        bool isGood;

        try
        {
            result = Int32.Parse(input);
            isGood = true;
        }
        catch (Exception)
        {
            result = Int32.MaxValue;
            isGood = false;
        }

        return isGood;
    }

    public static void DisposableResourcesAreDisposedWhenExceptionIsThrown(IDisposable disposableObject)
    {
        try
        {
            throw new Exception("*** Just because **");
        }
        finally
        {
            disposableObject.Dispose();
        }
    }
}
