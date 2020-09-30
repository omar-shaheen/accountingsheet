"use strict";

function IterarCamposEdit(t, n) {
   function i(t) {
      if (null == colsEdi) return !0;
      for (var n = 0; n < colsEdi.length; n++)
         if (t == colsEdi[n]) return !0;
      return !1
   }
   var o = 0;
   t.each(function () {
      o++, "buttons" != $(this).attr("name") && i(o - 1) && n($(this))
   })
}

function FijModoNormal(t) {
   $(t).parent().find(".bAcep").hide(), $(t).parent().find(".bCanc").hide(), $(t).parent().find(".bEdit").show(), $(t).parent().find(".bElim").show(), $(t).parents(".dyanmictable tr").attr("class", "")
}

function FijModoEdit(t) {
   $(t).parent().find(".bAcep").show(), $(t).parent().find(".bCanc").show(), $(t).parent().find(".bEdit").hide(), $(t).parent().find(".bElim").hide(), $(t).parents(".dyanmictable tr").attr("class", "editing")
}

function ModoEdicion(t) {
   return "editing" == t.attr("class")
}

function rowAcep(t) {
   var n = $(t).parents(".dyanmictable tr"),
      i = n.find(".dyanmictable td");
   ModoEdicion(n) && (IterarCamposEdit(i, function (t) {
      var n = t.find(".dyanmictable input").val();
      t.html(n)
   }), FijModoNormal(t), params.onEdit(n))
}

function rowCancel(t) {
   var n = $(t).parents(".dyanmictable tr"),
      i = n.find(".dyanmictable td");
   ModoEdicion(n) && (IterarCamposEdit(i, function (t) {
      var n = t.find(".dyanmictable div").html();
      t.html(n)
   }), FijModoNormal(t))
}

function rowEdit(t) {
   var n = $(t).parents(".dyanmictable tr"),
      i = n.find(".dyanmictable td");
   ModoEdicion(n) || (IterarCamposEdit(i, function (t) {
      var n = t.html(),
         i = '<div style="display: none;">' + n + "</div>",
         o = '<input class="form-control input-sm"  value="' + n + '">';
      t.html(i + o)
   }), FijModoEdit(t))
}

function rowElim(t) {
   $(t).parents(".dyanmictable tr").remove(), params.onDelete()
}

function rowAgreg() {
   if (0 == $tab_en_edic.find(".dyanmictable tbody tr").length) {
      var t = "";
      (i = $tab_en_edic.find(".dyanmictable thead tr").find("th")).each(function () {
         "buttons" == $(this).attr("name") ? t += colEdicHtml : t += "<td></td>"
      }), $tab_en_edic.find(".dyanmictable tbody").append("<tr>" + t + "</tr>")
   } else {
      var n = $tab_en_edic.find(".dyanmictable tr:last");
      n.clone().appendTo(n.parent());
      var i = (n = $tab_en_edic.find(".dyanmictable tr:last")).find(".dyanmictable td");
      i.each(function () {
         "buttons" == $(this).attr("name") || $(this).html("")
      })
   }
}

function TableToCSV(t) {
   var n = "",
      i = "";
   return $tab_en_edic.find(".dyanmictable tbody tr").each(function () {
      ModoEdicion($(this)) && $(this).find(".bAcep").click();
      var o = $(this).find(".dyanmictable td");
      n = "", o.each(function () {
         "buttons" == $(this).attr("name") || (n = n + $(this).html() + t)
      }), "" != n && (n = n.substr(0, n.length - t.length)), i = i + n + "\n"
   }), i
}
var $tab_en_edic = null,
   params = null,
   colsEdi = null,
   newColHtml = `
   <div class="btn-group pull-right">
     <button type="button" class="bEdit btn btn-sm btn-default" onclick="rowEdit(this);">
       <span class="icon-edit"> </span>
     </button>
     <button type="button" class="bElim btn btn-sm btn-default" onclick="rowElim(this);">
       <span class="icon-trash-empty"> </span>
     </button>
     <button type="button" class="bAcep btn btn-sm btn-default" style="display:none;" onclick="rowAcep(this);">
       <span class="icon-ok"> </span>
     </button>
     <button type="button" class="bCanc btn btn-sm btn-default" style="display:none;" onclick="rowCancel(this);">
       <span class="icon-cancel"></span>
     </button>
   </div>
   `,
   colEdicHtml = '<td name="buttons">' + newColHtml + "</td>";
$.fn.SetEditable = function (t) {
   var n = {
      columnsEd: null,
      $addButton: null,
      onEdit: function () {},
      onDelete: function () {},
      onAdd: function () {}
   };
   params = $.extend(n, t), this.find(".dyanmictable thead tr"), this.find(".dyanmictable tbody tr").append(colEdicHtml), $tab_en_edic = this, null != params.$addButton && params.$addButton.click(function () {
      rowAgreg()
   }), null != params.columnsEd && (colsEdi = params.columnsEd.split(","))
};