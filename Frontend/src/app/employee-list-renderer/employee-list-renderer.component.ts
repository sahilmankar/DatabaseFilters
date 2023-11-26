import { Component, Input } from '@angular/core';
import { Employee } from '../Employee';

@Component({
  selector: 'employee-list-renderer',
  templateUrl: './employee-list-renderer.component.html',
  styleUrls: ['./employee-list-renderer.component.css'],
})
export class EmployeeListRendererComponent {
  @Input() employees: Employee[] = [];
}
