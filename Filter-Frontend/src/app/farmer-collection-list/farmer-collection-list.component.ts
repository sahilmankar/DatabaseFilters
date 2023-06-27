import { Component, Input } from '@angular/core';
import { FarmerCollection } from '../farmer-collection';

@Component({
  selector: 'app-farmer-collection-list',
  templateUrl: './farmer-collection-list.component.html',
  styleUrls: ['./farmer-collection-list.component.css']
})
export class FarmerCollectionListComponent {
   @Input()farmerCollections: FarmerCollection[] = [];

}


