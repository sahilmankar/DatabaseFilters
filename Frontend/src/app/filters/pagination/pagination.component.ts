import {
  Component,
  EventEmitter,
  Input,
  Output,
  SimpleChanges,
} from '@angular/core';
import { PaginationHeader } from '../paginationHeader';

@Component({
  selector: 'pagination',
  templateUrl: './pagination.component.html',
  styleUrls: ['./pagination.component.css'],
})
export class PaginationComponent {
  @Input() paginationData: PaginationHeader | null = null;
  @Output() pageChangeEvent = new EventEmitter<number>();

  onClickPrevious() {
    if (this.paginationData) {
      let pageNumber = this.paginationData.CurrentPage - 1;
      this.pageChangeEvent.emit(pageNumber);
    }
  }

  onClickNext() {
    if (this.paginationData) {
      let pageNumber = this.paginationData.CurrentPage + 1;
      this.pageChangeEvent.emit(pageNumber);
    }
  }

}
