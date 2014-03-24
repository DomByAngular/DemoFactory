/***********************************
/* 创建人：xwf
/* 修改人：wk
/* 修改日期：2013-4-21
/* 大菜单效果和左侧切换选择效果
/* 依赖：easyloader.js,easyui.config.js
***********************************/
using('megamenu', function () {
    
    $('#menu').megaMenuCompleteSet({
        menu_speed_show: 0, // Time (in milliseconds) to show a drop down
        menu_speed_hide: 0, // Time (in milliseconds) to hide a drop down
        menu_speed_delay: 0, // Time (in milliseconds) before showing a drop down
        menu_effect: 'hover_slide', // Drop down effect, choose between 'hover_fade', 'hover_slide', etc.
        menu_click_outside: 1, // Clicks outside the drop down close it (1 = true, 0 = false)
        menu_show_onload: 0 // Drop down to show on page load (type the number of the drop down, 0 for none)
        
    });

    $(".drop3columns .col_3 a").click(function () {
        $(".dropcontent").hide();
    });
});


var select, targetId; //级联选中

function menuClick(obj, id) {
    debugger;
    if (targetId != null && targetId == id) {
        $("#_" + select).removeClass("current");
        select = $(obj).attr("id");
        $("#_" + select).addClass("current");
    } else {
        targetId = id;
        select = $(obj).attr("id");
        var url = $(id).attr("ref"); //加载菜单
        $('#west').empty().load(url);
    }
    $("#menu .drop").removeClass("selectLink");
    $(targetId).addClass("selectLink");
    $(".dropcontent").hide();
    $(".side-bx").removeClass("side-bx-toggled");
    $(".side-bx-bd").css("display","block");
    loadListPage(obj);
}

//加载列表
function loadListPage(obj) {
    debugger;
    $('#dlg').dialog('destroy');
    $('#center').empty().load($(obj).attr("ref"));
    
}

$(document).ready(function () {
    $("#menu .drop3columns").each(function (index, dom) {
        $(dom).find(".col_3:last").find("ul").addClass("botmnone");
    });
});