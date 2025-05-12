﻿using System.Globalization;

namespace Entity.Util.Utilities;

public static class FuncUtilities
{
    public static readonly string[] formatDate = new string[] { "dd/M/yyyy", "d/M/yyyy", "d/MM/yyyy", "dd/MM/yyy HH:mm:ss", "MM/dd/yyyy", "yyyy/MM/dd", "MM-dd-yyyy", "M-d-yyyy", "yyyy-MM-dd", "yyyy/M/d" };
   
    public static DateTime ConvertStringToDateTime(string date = "")
    {
        DateTime d;
        if (date.Split('-').Length > 1)
        {
            if (!string.IsNullOrEmpty(date))
            {
                d = DateTime.ParseExact(date, formatDate, CultureInfo.InvariantCulture);
            }
            else
            {
                d = DateTime.ParseExact(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            }
            return d;
        }
        if (!string.IsNullOrEmpty(date))
        {
            d = DateTime.ParseExact(date, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
        }
        else
        {
            d = DateTime.ParseExact(DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
        }
        return d;
    }

    public static DateTime ConvertStringToDate(string date="")
    {
        DateTime d;
        if (!string.IsNullOrEmpty(date))
        {
            d = DateTime.ParseExact(date, formatDate, CultureInfo.InvariantCulture);
        }
        else
        {
            d = DateTime.ParseExact(DateTime.Now.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }
        return d;
    }

    public static string ConvertDateToString(DateTime date)
    {
        var dateString = date.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
        return dateString;
    }

    public static bool BeAValidDate(string DateOfBirth)
    {
        if (DateTime.TryParseExact(DateOfBirth,
                   formatDate,
                   CultureInfo.InvariantCulture,
                   DateTimeStyles.None
                   , out _) && ConvertStringToDate(DateOfBirth) <= DateTime.Now)
        {
            return true;
        }
        return false;
    }

    public static bool BeAValidDateOfExpiry(string DateOfExpiry)
    {
        if (!DateTime.TryParseExact(DateOfExpiry,
                   formatDate,
                   CultureInfo.InvariantCulture,
                   DateTimeStyles.None
                   , out _))
        {
            return false;
        }
        return true;
    }
}