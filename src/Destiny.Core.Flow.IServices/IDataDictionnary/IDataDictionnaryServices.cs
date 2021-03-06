﻿using Destiny.Core.Flow.Dtos.DataDictionnary;
using Destiny.Core.Flow.Filter;
using Destiny.Core.Flow.Ui;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.IServices.IDataDictionnary
{
    public interface IDataDictionnaryServices
    {
        /// <summary>
        /// 创建一个数据字典
        /// </summary>
        /// <returns></returns>
        Task<OperationResponse> CreateAsync(DataDictionnaryInputDto input);
        /// <summary>
        /// 分页查询数据字典
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<PageResult<DataDictionaryOutPageListDto>> GetDictionnnaryPageAsync(PageRequest request);
        /// <summary>
        /// 修改数据字典
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<OperationResponse> UpdateAsync(DataDictionnaryInputDto input);
        /// <summary>
        /// 删除一个数据字典
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<OperationResponse> DeleteAsync(Guid id);
    }
}
