/***********************************
/* 创建人：wk
/* 修改人：wk
/* 修改日期：2013-5-5
/* 在easyloader.modules基础上扩展自定义多个模块，以便按需加载模块
/* 依赖：jquery.js,easyloader.js
***********************************/
//目前easyloader.base属性的当前Javascript文件默认路径为"http://xxxxxxxx/Scripts/jquery-core-easyui/"
//以下的路径表示在Scripts目录下
var basePath = '../../';

//扩展自定义的多个模块
easyloader.modules = $.extend(easyloader.modules, {
    easyuipublic: {
        js: basePath + 'jquery-common-easyui/easyui.public.js'
    },
    json2: {
        js: basePath + 'tool/json2.min.js'
    },
    megamenu: {
        js: basePath + 'megamenu/megamenu.js'
    },
    nano: {
        js: basePath + 'jquery-template/jquery.nano.js'
    },
    datagrid_detailview: {
        js: basePath + 'jquery-extension-easyui/datagrid-detailview.js'
    }
});

//默认使用公共模块'easyuipublic'，其对应js文件为easyui.public.js
var referenceModulesArr = ['easyuipublic'];

//当前IE7不支持josn对象,需要引用json2文件，用于对json数据转换处理
if ($.browser.msie && $.browser.version == 7.0) {
    //当前为IE7时引用json2模块，其对应js文件为json2.min.js
    referenceModulesArr.push('json2');
}

//在easyloader对象中自定义一个defaultReferenceModules属性，以便供所有不同功能模块重用默认引用的js模块
easyloader = $.extend(easyloader, {
    defaultReferenceModules: referenceModulesArr
});

easyloader.locale = 'zh_CN';

//------------------------------ 调整layout自适应浏览器大小 -------------------------------------//
$(document).ready(function () {

    $('#layout').height(getLayoutHeight());

    $(window).resize(function () {
//        var layoutHeight = getLayoutHeight();
//        $('#layout').height(layoutHeight);
//        $.parser.parse();
    });
});

//根据浏览器大小获取layout高度
function getLayoutHeight() {
    //$('.head_container').innerHeight()表示菜单所在div的高度
    return $(window).innerHeight() - $('.head_container').innerHeight();
}