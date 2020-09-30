$(document).ready(function () {

  $('.modal').on('shown.bs.modal', function () {
    $('html, body, table, tr, td, tbody').trigger('focus')
  })

  // $('#DyanmicTable').SetEditable({ $addButton: $('#addNewRow')});
  // $('.dyanmictable').SetEditable({ $addButton: $('.addNewRow')});
  // $('#dyanmictable2').SetEditableTwo({ $addButtonTwo: $('#addNewRow')});
  
  // $(".test-table").FullTable({
  //   "editable":true,
  //   "filterable":false,
  //   "orderable":false,
  //   "selectable":false,
  // });
  // $('.addNewRow').on('click', function () {
  //   $('.test-table').find("tr:last").after(`
  //     <tr>
  //       <td class="">1</td>
  //       <td class="editthis"><span>LE 400,250</span></td>
  //       <td style="min-width: 200px;" class="editthis"><span>عقار 1</span></td>
  //       <td class="selectable">
  //         <select class="form-control">
  //           <option value="">المشروع</option>
  //           <option value="">محمد</option>
  //           <option value="">ابراهيم</option>
  //         </select>
  //       </td>
  //       <td class="selectable">
  //         <select class="form-control">
  //           <option value="">المقاول</option>
  //           <option value="">على</option>
  //           <option value="">احمد</option>
  //         </select>
  //       </td>
  //       <td class=""> <input type="date" class="form-control"> </td>
  //       <td class="editthis">  <span>عقار رقم 102</span> </td>
  //     </tr>
  //   `)
  // });

  // $(".test-table2").FullTable({
  //   "editable":true,
  //   "filterable":false,
  //   "orderable":false,
  //   "selectable":false,
  // });

  $('.table-datatable').DataTable({
    autoWidth: false,
    paging: false,
    ordering: false,
    info: false,
    columnDefs: [{
      targets: ['_all'],
      className: 'mdc-data-table__cell'
    }],
    "oLanguage": {
      "sSearch": "البحث فى الجدول"
    }
  });



  


});
