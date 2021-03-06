﻿using Destiny.Core.Flow.Ui;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Filter.Abstract
{
    public interface IPagedResult<out TModel>: IResultBase
    {

        IReadOnlyList<TModel> ItemList { get; }
        int Total { get; }
    }
}
