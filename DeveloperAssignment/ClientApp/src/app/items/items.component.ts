import { ModuleRegistry } from '@ag-grid-community/core';
import { RowGroupingModule } from '@ag-grid-enterprise/row-grouping';
import { StatusBarModule } from '@ag-grid-enterprise/status-bar';
import { Component, OnInit } from '@angular/core';
import { ColDef, GridOptions } from 'ag-grid-community';
import 'ag-grid-enterprise';
import { AddItemDataRowComponent } from '../add-item-data-row/add-item-data-row.component';
import { ItemsService } from '../items.service';

//ModuleRegistry.registerModules([RowGroupingModule]);

@Component({
  selector: 'app-items',
  templateUrl: './items.component.html',
  styleUrls: ['./items.component.css']
})

export class ItemsComponent implements OnInit {
  public rowData!: any;
  private gridApi!: any;
  private gridColumnApi: any;
  public inputRow: {} = {};

  //#region define grid properties
  columnDefs: ColDef[] = [
    {
      headerName: "Category",
      field: "category",
      width: 500,
      rowGroup: true,
      enableRowGroup: true,
      rowGroupIndex: 0,
      hide: true,
      sortable: true
    },
    {
      headerName: "Items",
      field: "name",
      width: 400
    },
    {
      headerName: "Value",
      field: "value",
      width: 300,
      aggFunc: "sum",
      valueFormatter: params => this.currencyFormatter(params!.value, '$'),
    },
    {
      headerName: "Action",
      width: 100,
      cellRenderer: this.renderActionIcon.bind(this),
    }
  ];

  autoGroupColumnDef: any = {
    minWidth: 300,
    cellRendererParams: {
      footerValueGetter: (params: { node: { level: number; }; value: any; }) => {
        const isRootLevel = params.node.level === -1;
        if (isRootLevel) {
          return 'Grand Total';
        }
        return `Sub Total (${params.value})`;
      },
    }
  };

  gridOptions: GridOptions = <GridOptions>{
    animateRows: true,
    rowSelection: 'multiple',
    groupIncludeFooter: true,
    groupDefaultExpanded: 1,
    groupIncludeTotalFooter: true,
    autoGroupColumnDef: this.autoGroupColumnDef,
    suppressAggFuncInHeader: true,
    columnDefs: this.columnDefs,
    context: {
      itemService: this.itemsService
    },
    statusBar: {
      statusPanels: [
        {
          statusPanel: AddItemDataRowComponent,
          align:'left'
        },
      ],
    }
  };

  //#endregion

  constructor(private itemsService: ItemsService) {
    ModuleRegistry.registerModules([RowGroupingModule, StatusBarModule]);
  }

  ngOnInit(): void {
  }

  //#region value formatter and cell renderer
  currencyFormatter(currency: number, sign: string) {
    if (currency != null && currency !== undefined) {
      var sansDec = currency.toFixed(0);
      var formatted = sansDec.replace(/\B(?=(\d{3})+(?!\d))/g, ',');
      return sign + `${formatted}`;
    }
    else return '';
  }
  
  renderActionIcon(params: any) {
    const eDiv = document.createElement('div');
    if (params?.node?.parent?.leafGroup == true) {
      const self = this;
      eDiv.innerHTML = '<span><button style="background-color:transparent; outline:none; border:none;" (click)"><i class="fa fa-trash" data-action-type="delete"></i></button></span>';
      eDiv.addEventListener('click', (index) => {
        //console.log(params);
        //console.log(params.data);
        this.gridOptions.rowData?.splice(params.rowIndex, 1);
        this.gridApi.applyTransaction({ remove: [params.data] });
        //this.rowData.splice(params.rowIndex, 1);
        //console.log(this.rowData);

        this.itemsService.deleteItem(params.data.itemId).subscribe(result => {
        }, response => {
          console.log("Error : " + JSON.stringify(response));
        });
        return this.rowData;
      });
    }
    return eDiv;
  }
  //#endregion

  //#region grid ready event
  onGridReady(params: any) {
    this.itemsService.getCustomerItems().subscribe(result => {
      var itemDataArray = Object.values(result);
      this.rowData = [];
      this.rowData = itemDataArray;
    },
      (response: any) => {
        console.log("Error : " + JSON.stringify(response));
    });
    this.gridApi = params.api;
    this.gridColumnApi = params.columnApi;
  }
  //#endregion
}
