//从外部链接点进来就重置sessionStorage
//设置一个bool变量fromOut默认false并存入sessionStorage
//给外部链接添加事件，一旦点击则fromOut变为true
//这里的逻辑：
//如果fromOut为true，则清空sessionStorage，然后设置fromOut为false
$(function () {
    var fromOut = sessionStorage.getItem('fromOut');
    if (fromOut == 'true') {
        sessionStorage.clear();
        sessionStorage.setItem('fromOut', 'false');
        console.log('通过外部链接重置刷新页面');
    }
    console.log('内部刷新页面');
})

//根据option的状态决定操作列是否有编辑和删除
$(function () {
    var option = sessionStorage.getItem('option');
    if (option == 'onlyMe') {
        $('.operate').append('<a href="#" class="onlyMeOnly" data-toggle="modal" data-target="#EditModal">编辑</a>&nbsp');
        $('.operate').append('<a href="#" class="onlyMeOnly"data-toggle="modal" data-target="#DelModal">删除</a>');
    }
})

$(function () {
    $('#onlyMe').click(function () {
        sessionStorage.setItem('option', "onlyMe");
    })
    $('#all').click(function () {
        sessionStorage.setItem('option', "all");
    })
    //每次刷新页面时搜索框内容保留
    var searchContent = sessionStorage.getItem('searchStr');
    if (searchContent == 'null')
        searchContent = '';
    $('#searchBug').val(searchContent);

    var first = true;
    var _searchStr = "null";
    var _option = "all";
    $('#searchBtn').click(function () {
        var searchStr = $('#searchBug').val();
        //这里要与上次的_searchStr比较，如果不同，则可以触发点击事件
        if (searchStr != _searchStr) {
            _searchStr = searchStr;
            first = true;
            sessionStorage.setItem('searchStr', searchStr);
        }

        //同理对于option
        var option = sessionStorage.getItem('option');
        //console.log('option',option); null
        //如果用户没有选择，则默认给option赋值为"all"
        if (option == null || option == 'null') {
            option = 'all';
            sessionStorage.setItem('option', option);
        }
        if (option != _option) {
            _option = option;
            first = true;
            //sessionStorage.setItem('option', option);
        }

        $(this).attr('href', "/Bug/BugSearch?searchStr=" + searchStr +
            "&option=" + option + "&pageIndex=1");
        if (first) {
            $(this).trigger('click');
            first = !first;
        }
    })
})


function refresh() {
    var searchStr = sessionStorage.getItem('searchStr');
    var option = sessionStorage.getItem('option');
    window.location.replace('/bug/BugSearch?searchStr=' + searchStr + '&option='
        + option + '&pageIndex=1');
}