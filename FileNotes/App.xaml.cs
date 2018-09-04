using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace FileNotes
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
    }

    /* Readme
     * 
     * 文件管理注释工具 
     * 
     * 功能列表
     *  1) 文件目录 crud
     *  2) 注释
     *      2A) 修改文件注释 crud
     *      2B) 修改目录注释 crud
     *  3) 查询
     *      3A) 全文查找注释
     *      3B) 重复文件发现和去除重复
     *  4) 文件大小分析
     * 
     * 设计
     *    主窗口, 是一个tree view 做volume->folder -在左边, file item 在右边, 用 AvalonDockView 管理起来.
     *    上边是标准工具栏.
     *    
     * 
     * 
     */
}
