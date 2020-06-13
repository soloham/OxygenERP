/**
 * 值结构图构建工具
 */
(function($) {
    var nodeCount = 0;
    $.fn.orgChat = function(options) {
        // 默认值
        var defaults = {
            depth: -1,
            chartClass: "org-chart",
            data: [],
            rootId: 0,
            showOrderNum: true
        };
        var opts = $.extend({}, defaults, options);
        var $appendTo = $(this);
        var $container = $("<div class='" + opts.chartClass + "'/>");
        buildNode($container, 0, opts.rootId, opts);
        $appendTo.append($container);
    }
    // 构建org
    function buildNode($appendTo, level, rootId, opts) {
        var data = opts.data;
        //根据rootId查找节点
        var node = {};
        if (data != undefined && data.length > 0) {
            $.each(data, function (i, item) {
                if (item.id == rootId) {
                    node = item;
                }
            });
        }
        var $table = $("<table cellpadding='0' cellspacing='0' border='0'/>");
        var $tbody = $("<tbody/>");
        var $nodeRow = $("<tr/>").addClass("node-cells");
        var $nodeCell = $("<td/>").addClass("node-cell").attr("colspan", 2);

        //获得子节点
        var $childNodes = $.grep(data, function (n) {
            if (n.parentId == rootId)
                return true;
        });
        //排序
        $childNodes.sort(function (a, b) {
            return a.orderNum - b.orderNum;
        });

        if ($childNodes.length > 1) {
            $nodeCell.attr("colspan", $childNodes.length * 2);
        }
        //Increaments the node count which is used to link the source list and the org chart
        nodeCount++;

        //折叠处理
        var $foldDiv = null;
        if ($childNodes.length > 0 && (opts.depth == -1 || level + 1 < opts.depth)) {
            var foldFlag = "";
            if (node.collapsed) {
                foldFlag = "+";
            } else {
                foldFlag = "-";
            }
            $foldDiv = $("<div>").addClass("fold-sign").append(foldFlag);
        }
        //创建节点
        var $nodeDiv = $("<div>").addClass("node")
            .addClass(node.nodeClass)
            .data("tree-node", nodeCount)
        //节点name
        var nameContent = node.name;
        if (node.url != null && node.url != undefined && node.url != "") {
            nameContent = $("<a>").addClass("content-url")
                .attr("target", "_blank")
                .attr("href", node.url)
                .append(node.name);
        } else {
            nameContent = $("<span>").addClass("content-name")
                .append(node.name);
        }
        //节点OrderNum
        var orderNumContent = null;
        if (opts.showOrderNum) {
            if (isEffective(node.orderNum)) {
                orderNumContent = $("<span>").addClass("order-num").append(node.orderNum);
            }
        }

        $nodeDiv.append(orderNumContent);
        $nodeDiv.append(nameContent);

        // Expand and contract nodes
        if ($childNodes.length > 0 && isEffective($foldDiv)) {
            $foldDiv.click(function () {
                var $this = $(this);
                var $tr = $this.closest("tr");

                if ($tr.hasClass('contracted')) {
                    $tr.removeClass('contracted').addClass('expanded');
                    $tr.nextAll("tr").css('visibility', '');
                    $foldDiv.html("-");
                } else {
                    $tr.removeClass('expanded').addClass('contracted');
                    $tr.nextAll("tr").css('visibility', 'hidden');
                    $foldDiv.html("+");
                }
            });
        }

        $nodeCell.append($nodeDiv);
        if (isEffective($foldDiv)) {
            $nodeCell.append($foldDiv);
        }
        $nodeRow.append($nodeCell);
        $tbody.append($nodeRow);

        if ($childNodes.length > 0) {
            // recurse until leaves found (-1) or to the level specified
            if (opts.depth == -1 || (level + 1 < opts.depth)) {
                var $downLineRow = $("<tr/>");
                var $downLineCell = $("<td/>").attr("colspan", $childNodes.length * 2);
                $downLineRow.append($downLineCell);

                // draw the connecting line from the parent node to the horizontal line
                $downLine = $("<div></div>").addClass("line down");
                $downLineCell.append($downLine);
                $tbody.append($downLineRow);

                // Draw the horizontal lines
                var $linesRow = $("<tr/>");
                //遍历子节点，添加结构图链接线
                $.each($childNodes, function (i, n) {
                    var $left = $("<td>&nbsp;</td>").addClass("line left top");
                    var $right = $("<td>&nbsp;</td>").addClass("line right top");
                    $linesRow.append($left).append($right);
                });

                // horizontal line shouldn't extend beyond the first and last child branches
                $linesRow.find("td:first")
                    .removeClass("top")
                    .end()
                    .find("td:last")
                    .removeClass("top");

                $tbody.append($linesRow);
                var $childNodesRow = $("<tr/>");
                //遍历子节点，递归添加下一级节点
                $.each($childNodes, function (i, item) {
                    var $td = $("<td class='node-container'/>");
                    $td.attr("colspan", 2);
                    // recurse through children lists and items
                    buildNode($td, level + 1, item.id, opts);
                    $childNodesRow.append($td);
                });
            }
            $tbody.append($childNodesRow);
        }

        if ($childNodes != undefined && $childNodes.length > 0) {
            $.each($childNodes, function (i, item) {
                if (node.collapsed) {
                    $nodeRow.nextAll('tr').css('visibility', 'hidden');
                    $nodeRow.removeClass('expanded');
                    $nodeRow.addClass('contracted');
                } else {
                    $nodeDiv.addClass(item);
                }
            });
        }

        $table.append($tbody);
        $appendTo.append($table);

        /* Prevent trees collapsing if a link inside a node is clicked */
        $nodeDiv.children('a').click(function (e) {
            console.log(e);
            e.stopPropagation();
        });
    };
    /**
     * 判断值是否有效
     * @param val 值
     */
    function isEffective(val){
        if(val!=null && val!=undefined && val!=""){
            return true;
        }
        return false;
    }

})(jQuery);
