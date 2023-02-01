import {Component} from '@angular/core';
import {CommonModule} from '@angular/common';

@Component({
  selector: 'app-footer',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.scss']
})
export class FooterComponent {
  socialData = [
    {url: 'https://twitter.com/rexx07', name: 'Twitter', img: './assets/svg/twitter.svg'},
    {url: 'https://github.com/rexx07', name: 'Github', img: './assets/svg/github.svg'}
  ];

  constructor() {
  }
}
