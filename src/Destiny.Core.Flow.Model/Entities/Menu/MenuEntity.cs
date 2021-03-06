﻿using Destiny.Core.Flow.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Destiny.Core.Flow.Model.Entities.Menu
{
    [DisplayName("菜单实体")]
    public class MenuEntity : EntityBase<Guid>, IFullAuditedEntity<Guid>
    {
        /// <summary>
        /// 菜单名称
        /// </summary>
        [DisplayName("菜单名称")]
        public string Name { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        [DisplayName("排序")]
        public int Sort { get; set; }
        /// <summary>
        /// 组件地址(前端)
        /// </summary>
        [DisplayName("组件地址(前端)")]
        public string RouterPath { get; set; }
        /// <summary>
        /// 父级菜单ID
        /// </summary>
        [DisplayName("父级菜单ID")]
        public Guid ParentId { get; set; }
        /// <summary>
        /// 菜单图标
        /// </summary>
        [DisplayName("菜单图标")]
        public string Iocn { get; set; }
        /// <summary>
        ///  获取或设置 最后修改用户
        /// </summary>
        [DisplayName("最后修改用户")]
        public virtual Guid? LastModifierUserId { get; set; }
        /// <summary>
        /// 获取或设置 最后修改时间
        /// </summary>
        [DisplayName("最后修改时间")]
        public virtual DateTime? LastModifierTime { get; set; }
        /// <summary>
        ///获取或设置 是否删除
        /// </summary>
        [DisplayName("是否删除")]
        public virtual bool IsDeleted { get; set; }
        /// <summary>
        ///获取或设置 创建用户ID
        /// </summary>
        [DisplayName("创建用户ID")]
        public virtual Guid? CreatorUserId { get; set; }
        /// <summary>
        ///获取或设置 创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public virtual DateTime CreatedTime { get; set; }
        /// <summary>
        ///获取或设置 描述
        /// </summary>
        [DisplayName("描述")]
        public virtual string Description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DisplayName("当前菜单以上所有的父级")]
        public string ParentNumber { get; set; }

        /// <summary>
        /// 深度
        /// </summary>
        [DisplayName("深度")]
        public int Depth { get; set; }
    }
}
