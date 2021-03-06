﻿using Destiny.Core.Flow.Dependency;
using Destiny.Core.Flow.Dtos.Menu;
using Destiny.Core.Flow.ExpressionUtil;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Filter;
using Destiny.Core.Flow.IServices.IMenu;
using Destiny.Core.Flow.Model.Entities.Menu;
using Destiny.Core.Flow.Model.Entities.Rolemenu;
using Destiny.Core.Flow.Repository.MenuRepository;
using Destiny.Core.Flow.Ui;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.Services.Menu
{
    [Dependency(ServiceLifetime.Scoped)]
    public class MenuServices : IMenuServices
    {
        private readonly IMenuRepository _menuRepository = null;
        private readonly IEFCoreRepository<RolemenuEntity, Guid> _roleMenuRepository;

        public MenuServices(IMenuRepository menuRepository, IEFCoreRepository<RolemenuEntity, Guid> roleMenuRepository)
        {
            _menuRepository = menuRepository;
            _roleMenuRepository = roleMenuRepository;
        }

        public async Task<OperationResponse> CareateAsync(MenuInputDto input)
        {
            input.NotNull(nameof(input));
            var response = await _menuRepository.InsertAsync(input);
            return response;
        }

        public async Task<OperationResponse> DeleteAsync(Guid id)
        {
            return await _menuRepository.DeleteAsync(id);
        }

        public async Task<OperationResponse> UpdateAsync(MenuInputDto input)
        {
            input.NotNull(nameof(input));
            return await _menuRepository.UpdateAsync(input);
        }

        public async Task<PageResult<MenuOutPageListDto>> GetMenuPageAsync(PageRequest requst)
        {
            requst.NotNull(nameof(requst));
            var expression = FilterHelp.GetExpression<MenuEntity>(requst.Filters);
            return await _menuRepository.TrackEntities.ToPageAsync<MenuEntity, MenuOutPageListDto>(expression, requst);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleid">角色Id</param>
        /// <returns></returns>
        public async Task<TreeResult<MenuOutDto>> GetMenuAsync(Guid roleid)
        {
            var rolelist = new List<RolemenuEntity>();
            var list = await _menuRepository.Entities.ToTreeResultAsync<MenuEntity, MenuOutDto>(
                (r, c) =>
                {
                    return c.ParentId == null || c.ParentId == Guid.Empty;
                }, (p, q) =>
                {
                    return p.Id == q.ParentId;
                }, (p, q) =>
                {
                    if (p.children == null)
                    {
                        p.children = new List<MenuOutDto>();
                    }

                    p.children.AddRange(q);
                });
            if(roleid!=Guid.Empty)
                rolelist = await _roleMenuRepository.Query(x => x.RoleId == roleid).ToListAsync();
            if (rolelist.Any())
                IscheckTree(rolelist,list.Data);
            return list;
        }
        /// <summary>
        /// 处理角色权限数据
        /// </summary>
        /// <param name="rolelist"></param>
        /// <param name="list"></param>
        private void IscheckTree(List<RolemenuEntity> rolelist, IEnumerable<MenuOutDto> list)
        {
            foreach (var item in list)
            {
                var model = rolelist.Where(s => s.MenuId == item.Id).FirstOrDefault();
                if (model != null)
                    item.@checked = true;
                IscheckTree( rolelist, item.children);
            }
        }
        public async Task<PageResult<MenuTableOutDto>> GetMenuTableAsync(PageRequest requst)
        {
            requst.NotNull(nameof(requst));
            var expression = FilterHelp.GetExpression<MenuEntity>(requst.Filters);

            return await _menuRepository.TrackEntities.ToPageAsync<MenuEntity, MenuTableOutDto>(expression, requst);
        }
    }
}