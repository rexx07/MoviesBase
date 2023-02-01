import {Component, Input} from '@angular/core';
import {CommonModule} from '@angular/common';
import {RouterLink} from "@angular/router";
import {ImgMissingDirective} from "../../core/directives/img-missing.directive";

@Component({
  selector: 'app-poster-card',
  standalone: true,
  imports: [CommonModule, RouterLink, ImgMissingDirective],
  templateUrl: './poster-card.component.html',
  styleUrls: ['./poster-card.component.scss']
})
export class PosterCardComponent {
  @Input() model: any;
  @Input() isMovie: boolean = false;

  constructor() {
  }
}
