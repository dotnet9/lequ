﻿namespace Lequ.Model.ViewModels
{
    public class PagingViewModelBase<T>
    {
        public int PageIndex { get; set; }

        public int PageCount { get; set; }

        public List<T>? Datas { get; set; }
    }
}
