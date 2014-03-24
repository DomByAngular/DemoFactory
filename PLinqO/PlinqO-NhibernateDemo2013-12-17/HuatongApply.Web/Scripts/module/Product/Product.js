/***********************************
/* 创建人：xwf
/* 修改人：wk
/* 修改日期：2013-5-5
/* 包含列表的绑定,增删改查
/* 依赖：easyloader.js,easyui.config.js
***********************************/
//easyloader.defaultReferenceModules表示默认引用easyui.public.js,如果当前IE7时会自动附加引用json2.min.js
using(easyloader.defaultReferenceModules, function () {
    
    //在html片段加载完毕以后，处理组件样式渲染过程
    $.parser.parse();
    
    // 列表参数设置
    var dataGridOptions = {
        columns: [[
            { field: 'Itemid', checkbox: true },
            { field: 'Productid', title: 'Product', width: 100, sortable: true },
            { field: 'Listprice', title: 'Listprice', width: 80, align: 'right', sortable: true },
            { field: 'Unitcost', title: 'Unitcost', width: 80, align: 'right', sortable: true },
            { field: 'Attr1', title: 'Attr1', width: 250 },
            { field: 'Status', title: 'Status', width: 60, align: 'center' }

        ]],
        singleSelect:false,
        toolbar:'#toolbar',
        sortName:'Itemid',
        sortOrder:'asc',
        rownumbers:true ,
        pagination:true,
        loader: function (param, success, error) {
            var paramStr = "{order:'" + param.order + "', page:" + param.page + ", rows:" + param.rows + ", sort:'" + param.sort + "'}";
            ajaxCRUD({
                url: '/WebServices/ProductWebService/ProductWebService.asmx/GetProducts',
                data: paramStr,
                success: function (data) {
                    success(data);
                },
                error: function () {
                    error.apply(this, arguments);
                }
            });

        },
        onLoadSuccess: function () {
            //预先加载模板
            $("#formTemplate").load("Views/Product/ProductForm.htm", function () {
                //在html片段加载完毕以后，处理组件样式渲染过程
                $.parser.parse();
            });
        },
        onDblClickRow: function (rowIndex, rowData) {
            fillForm(rowData.Itemid);
        }
    };

    //初始化列表组件
    iniDataGrid('dg', dataGridOptions);
});  


//点击“新增”按钮
function addData() {
    //第一个参数是对话框的id
    //第二个参数是对应easyui弹出层组件的options参数设置
    openDialog('dlg', {
        title: '新增',
        iconCls: 'icon-save'
    });
}

//点击“编辑”按钮
function editData() {
    var row = getSelectedRow('dg');
    if (row == null) {
        msgShow('编辑', '请选择要编辑的一行数据', '');
    } else {
        fillForm(row.Itemid);
    }
}

//获取JSON数据并填充到相应表单
function fillForm(itemid) {
    ajaxCRUD({
        url: 'WebServices/ProductWebService/ProductWebService.asmx/GetOneProduct',
        data: "{pItemid:'" + itemid + "'}",
        success: function (data) {
            //打开对话框
            openDialog('dlg', {
                title: '编辑',
                iconCls: 'icon-edit'
            });
            
            //JSON数据填充表单
            loadDataToForm('ff', data);
        }
    });
}

//保存表单数据
function saveData() {
    var hidValue = $("#Itemid").val();
    var basicUrl = 'WebServices/ProductWebService/ProductWebService.asmx/';

    var wsMethod = '';
    if (hidValue.length > 0) {
        wsMethod = "UpdateProduct"; //修改
    } else {
        wsMethod = "AddProduct"; //新增
    }

    var formUrl = basicUrl + wsMethod;

    var form2JsonObj = form2Json("ff");
    var form2JsonStr = JSON.stringify(form2JsonObj);
    var jsonDataStr = "{pProduct:" + form2JsonStr + "}";

    ajaxCRUD({
        url: formUrl,
        data: jsonDataStr,
        success: function (data) {
            if (data == true) {
                closeDialogAndClearForm();
                refreshTable('dg');
            }
        }
    });
} // end saveData()

//批量删除前台提示
function deleteDatas() {
    deleteItems('dg', deleteDatasAjax);
}

//批量删除后台AJAX处理
function deleteDatasAjax(str) {
    ajaxCRUD({
        url: '/WebServices/ProductWebService/ProductWebService.asmx/DeleteProducts',
        data: "{pIds:'" + str + "'}",
        success: function (data) {
            if (data == true) {
                refreshTable('dg');
            }
        },
        error: function () {
            error.apply(this, arguments);
        }
    });
}

//关闭弹出层同时清空表单
function closeDialogAndClearForm() {
    closeDialog('dlg');
}