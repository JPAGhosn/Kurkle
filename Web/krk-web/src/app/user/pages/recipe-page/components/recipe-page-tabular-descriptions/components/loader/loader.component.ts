import {Component} from '@angular/core';
import {MatProgressSpinner} from '@angular/material/progress-spinner';

@Component({
  selector: 'krk-loader',
  standalone: true,
  imports: [
    MatProgressSpinner
  ],
  templateUrl: './loader.component.html',
  styleUrl: './loader.component.scss'
})
export class LoaderComponent {

}