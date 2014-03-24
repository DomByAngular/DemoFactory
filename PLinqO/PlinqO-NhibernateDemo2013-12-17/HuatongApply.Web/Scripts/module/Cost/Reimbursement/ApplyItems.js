/***********************************
/* 创建人：ys
/* 修改日期：2013-12-02
/* 包含列表的绑定,增删改查
***********************************/
//easyloader.defaultReferenceModules表示默认引用easyui.public.js,如果当前IE7时会自动附加引用json2.min.js
using(easyloader.defaultReferenceModules, function () {

    // 列表参数设置
    var dataGridOptions = {
        title: '报销项管理',
        columns: [[
            { field: 'ItemId', checkbox: true },
            { field: 'ItemName', title: '报销项目名称', width: 150, sortable: false },
            { field: 'CreatedBy', title: '创建人', width: 150, align: 'left' },
            { field: 'CreatedOnDateLongStr', title: '创建时间', width: 150, align: 'left' }  
        ]],
        singleSelect: false,
        toolbar: '#toolbar',
        sortName: 'CreatedOn',
        sortOrder: 'desc',
        rownumbers: true,
        pagination: true,
        loader: function (param, success, error) {
            var datas = {
                pageIndex: param.page,
                pageSize: param.rows,
                order: param.order,
                sort: param.sort,
                applyItemBo: {}
            };
            var paramStr = JSON.stringify(datas);

            ajaxCRUD({
                url: 'WebServices/CostWebService/ReimbursementWebService/ReimbursementWebService.asmx/GetApplyItems',
                data: paramStr,
                success: function (data) {
                    success(data);
                },
                error: function () {
                    error.apply(this, arguments);
                }
            });
        }
    };
    //初始化列表组件
    iniDataGrid('dg', dataGridOptions);
});

//easyloader.defaultTime为700ms
setTimeout(loadPartialHtml, easyloader.defaultTime);

function loadPartialHtml() {
    if ($('.window').length == 0) {
        panel('formTemplate', {
            href: 'Views/Cost/Reimbursement/Items/ApplyitemForm.htm',
            onLoad: function () {
                setValidatebox('ItemName', {
                    validType: "unique['WebServices/CostWebService/ReimbursementWebService/ReimbursementWebService.asmx/CheckUniqueApplyItemName','HidItemId','HidItemName','itemName','项目名称']"
                });
            }
        });
    }
}

var moduleName = '报销项目-';

//点击“新增”按钮
function addData() {
    openDialog('dlg', {
        title: moduleName + '新增',
        iconCls: 'icon-add'
    });
    resetFormAndClearValidate('ff');
}

//点击“编辑”按钮
function editData() {
    var row = getSelectedRow('dg');
    if (row == null) {
        msgShow(moduleName + '编辑', '请选择要编辑的一行数据', '');
    } else {
        resetFormAndClearValidate('ff');
        fillForm(row.ItemId);
    }
}

//获取JSON数据并填充到相应表单
function fillForm(itemid) {
    ajaxCRUD({
        url: 'WebServices/CostWebService/ReimbursementWebService/ReimbursementWebService.asmx/GetApplyitemBoById',
        data: "{id:'" + itemid + "'}",
        success: function (data) {
            openDialog('dlg', {
                title: moduleName + '编辑',
                iconCls: 'icon-edit'
            });
            data.HidItemName = data.ItemName;
//            data.ItemId = data.ItemId;
            //JSON数据填充表单
            loadDataToForm('ff', data);
        }
    });
}

//保存表单数据
function saveData() {
    if (!formValidate('ff')) {
        return;
    }
    var isUsed = checkItemName($('#ItemName').val());
    if (isUsed) {
        msgShow("提示", "该项目名称已经存在", 'info');
        return;
    }
    var hidValue = $("#HidItemId").val();
    var basicUrl = 'WebServices/CostWebService/ReimbursementWebService/ReimbursementWebService.asmx/';

    var wsMethod = '';
    if (hidValue.length > 0) {
        wsMethod = "UpdateApplyItem"; //修改
    } else {
        wsMethod = "AddApplyItem"; //新增
    }

    var formUrl = basicUrl + wsMethod;
    var form2JsonObj = form2Json("ff");
    var form2JsonStr = JSON.stringify(form2JsonObj);
    var jsonDataStr = "{applyitemBo:" + form2JsonStr + "}";

    ajaxCRUD({
        url: formUrl,
        data: jsonDataStr,
        success: function (data) {
            var msg = '';
            if (hidValue.length > 0) {
                msg = "修改成功"; //修改
            } else {
                msg = "新增成功"; //新增
            }
            if (data == true) {
                msgShow('提示', msg, 'info');
                closeFormDialog();
                refreshTable('dg');
            } else { msgShow('提示', '提交失败', 'info'); }
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
        url: 'WebServices/CostWebService/ReimbursementWebService/ReimbursementWebService.asmx/DeleteApplyItemsByIds',
        data: "{ids:'" + str + "'}",
        success: function (data) {
            if (data == true) {
                msgShow('提示', '删除成功', 'info');
                refreshTable('dg');
            } else {
                msgShow('提示', '删除失败', 'info');
            }
        }
    });
}

function Search() {
    // 列表参数设置
    var dataGridOptions = {
        pageNumber: 1,
        loader: function (param, success, error) {
            var organizationData = {
                pageIndex: param.page,
                pageSize: param.rows,
                order: param.order,
                sort: param.sort,
                applyItemBo: {
                    ItemName: $('#txtItemNameSearch').val()
                }
            };
            var paramStr = JSON.stringify(organizationData);
            ajaxCRUD({
                url: 'WebServices/CostWebService/ReimbursementWebService/ReimbursementWebService.asmx/GetApplyItems',
                data: paramStr,
                success: function (data) {
                    success(data);
                },
                error: function () {
                    error.apply(this, arguments);
                }
            });
        }
    };
    //初始化列表组件
    iniDataGrid('dg', dataGridOptions);
}

function clearSearchCriteria() {
    clearForm('advancedSearch');
}

//关闭弹出层
function closeFormDialog() {
    closeDialog('dlg');
}

//提交的似乎后再次检测用户名是否已经被使用
function checkItemName(name) {
    var result = false;
    ajaxCRUD({
        url: 'WebServices/CostWebService/ReimbursementWebService/ReimbursementWebService.asmx/CheckUniqueApplyItemName',
        data: "{itemName:'" + name + "'}",
        async:false,
        success: function (data) {
            result= data;
        }
    });
    return result;
}
