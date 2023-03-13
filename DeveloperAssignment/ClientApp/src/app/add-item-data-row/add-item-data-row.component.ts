import { IStatusPanelParams } from '@ag-grid-community/core';
import { Component } from '@angular/core';

@Component({
  selector: 'app-add-item-data-row',
  templateUrl: './add-item-data-row.component.html',
  styleUrls: ['./add-item-data-row.component.css']
})
export class AddItemDataRowComponent //implements IStatusPanelComp {
{
  params!: IStatusPanelParams;
  eGui!: HTMLDivElement;
  eTxt!: HTMLInputElement;
  eBtn!: HTMLButtonElement;
  eNumericInput!: HTMLInputElement;
  eSelectInput!: HTMLSelectElement;
  buttonListener: any;

  init(params: IStatusPanelParams) {
    this.params = params;

    enum Categories {
      Electronics = 1,
      Kitchen,
      Clothing,
      Automobiles,
      Cameras,
      Jewellery,
      'Musical Instruments',
      'Sporting Equipment'
    }

    //#region add controls to status panel
    this.eTxt = <HTMLInputElement>document.createElement('INPUT');
    this.eTxt.setAttribute("type", "text");
    this.eTxt.setAttribute("placeholder", "Item Name");
    this.eTxt.style.padding = '5px';
    this.eTxt.style.margin = '2px';

    this.eNumericInput = <HTMLInputElement>document.createElement('INPUT');
    this.eNumericInput.setAttribute("type", "number");
    this.eNumericInput.style.width = '70px';
    this.eNumericInput.style.padding = '5px';
    this.eNumericInput.style.margin = '5px';

    this.eSelectInput = <HTMLSelectElement>document.createElement('SELECT');
    var filteredCategories = Object.values(Categories).filter(x => isNaN(Number(x)))
    var cnt: number = 0;
    for (let i = 0; i < filteredCategories!.length; i++) {
      var option = document.createElement('option');
      {
        cnt++
        option.text = filteredCategories[i].toString();
        option.value = cnt.toString();
      }
      this.eSelectInput.add(option);
    }
    this.eSelectInput.style.padding = '5px';
    this.eSelectInput.style.margin = '5px';

    this.eBtn = document.createElement('button');
    this.buttonListener = this.onButtonClicked.bind(this);
    this.eBtn.addEventListener('click', this.buttonListener);
    this.eBtn.innerHTML = 'Add';
    this.eBtn.style.padding = '5px';
    this.eBtn.style.margin = '5px';

    this.eGui = document.createElement('div');
    this.eGui.className = 'ag-status-name-value';
    this.eGui.style.width = "500px";

    this.eGui.appendChild(this.eTxt);
    this.eGui.appendChild(this.eNumericInput);
    this.eGui.appendChild(this.eSelectInput);
    this.eGui.appendChild(this.eBtn);
    //#endregion 
  }

  getGui() {
    return this.eGui;
  }

  destroy() {
    this.eGui.removeEventListener('click', this.buttonListener);
  }

  //#region button click event
  onButtonClicked() {
    var newItemData: any;
    newItemData = [{
      'name': this.eTxt.value, 'value': + this.eNumericInput.value,
      'category': this.eSelectInput.selectedOptions[0].text, 'categoryId': Number(this.eSelectInput.selectedOptions[0].value)
    }];
    this.params.api!.applyTransaction({ add: newItemData });

    //save new record in DB
    var newData = {
      'ItemId': "0", 'Name': this.eTxt.value, 'Value': + this.eNumericInput.value,
      'Category': this.eSelectInput.selectedOptions[0].text, 'CategoryId': Number(this.eSelectInput.selectedOptions[0].value)
    };
    this.params.context.itemService!.addItem(newData).subscribe((result: any) => {
    }, (response: any) => {
      console.log("Error : " + JSON.stringify(response));
    });

    //refresh data
    this.params.context.itemService!.getCustomerItems().subscribe((result: any[]) => {
      var itemDataArray = Object.values(result);
      this.params.api.setRowData(itemDataArray);
    },
      (response: any) => {
        console.log("Error : " + JSON.stringify(response));
      });

    //reset fields
    this.eNumericInput.value = '';
    this.eTxt.value = '';
    this.eTxt.placeholder = 'Item Name';
    this.eSelectInput.selectedIndex = 0;
  }
  //#endregion
}

