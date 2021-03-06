﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nikita.Base.Define;

namespace Nikita.Assist.IDBuilder
{
    public interface IIDBuilder
    {
        long GetNewID( SqlType dbType, string strTableName, string strConn);

        string GetSeriesNumber( SqlType dbType, string strType, string strTableName, string strTableField, string strPreficLength, bool blnDt, int intFyId, string strConn);
    }
}