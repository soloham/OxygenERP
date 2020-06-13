## 介绍
这是一个生成组织结构图的前端工具。依赖于jquery。

## 示例

![demo](https://github.com/jiangbaojun/jQueryOrgChart/blob/master/images/demo.gif?raw=true)

## 使用

###　安装依赖包

npm位置:[https://www.npmjs.com/package/jq-orgchart](https://www.npmjs.com/package/jq-orgchart)
```
# install packages(npm)
$ npm install jq-orgchart --save

# install packages(bower)
$ bower install jq-orgchart --save
```

###　引用
```
    引入基础css
    <link rel="stylesheet" href="css/jquery.jOrgChart.css"/>
    引入自定义css，可以修改成自己想要的样式
    <link rel="stylesheet" href="css/custom.css"/>
    
    本工具依赖于jQuery，首先引入jQuery
    <script type="text/javascript" src="js/jquery-min.js"></script>
    引入主体js
    <script src="js/jquery.jOrgChart.js"></script>
```

###　用法示例
```
<script>
        // data数据
        var data = [
            {id: "0", name: "根节点", collapsed: false, url: ""},
            {id: "1", parentId: "0", name: "页面", collapsed: false, url: "", orderNum: 1,nodeClass:"male"},
            {id: "2", parentId: "0", name: "表单", collapsed: false, url: "", orderNum: 2,nodeClass:"male"},
            {id: "5", parentId: "0", name: "其它", collapsed: true, url: "", orderNum: 3,nodeClass:"male"},
            {id: "3", parentId: "1", name: "查询1", collapsed: true, url: "", orderNum: 1,nodeClass:"male"},
            {id: "4", parentId: "2", name: "表单1", collapsed: false, url: "http://www.baidu.com", orderNum: 1,nodeClass:"male"},
            {id: "6", parentId: "5", name: "其他1", collapsed: false, url: "http://www.baidu.com", orderNum: 1,nodeClass:"male"},
            {id: "7", parentId: "1", name: "查询2", collapsed: false, url: "", orderNum: 2,nodeClass:"male"},
            {id: "10", parentId: "7", name: "查询2-1", collapsed: false, url: "http://www.baidu.com", orderNum: 1,nodeClass:"male"},
            {id: "8", parentId: "3", name: "查询1-1", collapsed: true, url: "", orderNum: 1,nodeClass:"male"},
            {id: "9", parentId: "8", name: "查询1-1-1", collapsed: false, url: "http://www.baidu.com", orderNum: 1,nodeClass:"male"}
        ];
        // options选项
        var options={
            data : data,
            showOrderNum: true,
            rootId : 0
        };
        $(function(){
            $("#chart").orgChat(options);
        });
    </script>
    
    <div id="chart" class="orgChart"></div>
```

## data数据选项
<table>
  <thead>
    <tr><th>选项</th><th>类型</th><th>描述</th></tr>
  </thead>
  <tbody>
    <tr>
      <td>id</td><td>string</td><td>数据节点id</td>
    </tr>
    <tr>
      <td>parentId</td><td>string</td><td>数据节点父id</td>
    </tr>
    <tr>
      <td>name</td><td>json array</td><td>节点名称</td>
    </tr>
    <tr>
      <td>collapsed</td><td>boolean</td><td>是否折叠</td>
    </tr>
    <tr>
      <td>url</td><td>number</td><td>节点超地址链接</td>
    </tr>
    <tr>
      <td>orderNum</td><td>boolean</td><td>同级节点顺序编号</td>
    </tr>
    <tr>
      <td>nodeClass</td><td>boolean</td><td>自定义node节点class</td>
    </tr>
  </tbody>
</table>

## options选项

<table>
  <thead>
    <tr><th>选项</th><th>类型</th><th>默认</th><th>描述</th></tr>
  </thead>
  <tbody>
    <tr>
      <td>depth</td><td>number</td><td>-1</td><td>显示级数限制，-1为不限制</td>
    </tr>
    <tr>
      <td>chartClass</td><td>string</td><td>"org-chart"</td><td>结构图容器class名称</td>
    </tr>
    <tr>
      <td>data</td><td>json array</td><td>[]</td><td>结构图数据</td>
    </tr>
    <tr>
      <td>rootId</td><td>number</td><td>0</td><td>根节点</td>
    </tr>
    <tr>
      <td>showOrderNum</td><td>boolean</td><td>true</td><td>是否显示orderNum</td>
    </tr>
  </tbody>
</table>

## 说明
参考 [wesnolte](https://github.com/wesnolte) 的 [jOrgChart](https://github.com/wesnolte/jOrgChart)