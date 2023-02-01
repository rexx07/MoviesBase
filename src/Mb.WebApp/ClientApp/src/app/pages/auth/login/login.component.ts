import {Component, OnInit} from '@angular/core';
import {AuthService, storage} from "../../../core";


@Component({
  selector: 'app-login',
  standalone: true,
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  form: any = {
    username: null,
    password: null
  };
  isLoginFailed = false;
  isLoggedIn = false;
  errorMessage = '';
  roles: string[] = [];

  constructor(private authService: AuthService) {
  }

  ngOnInit(): void {
    if (this.authService.isLoggedIn) {
      this.isLoggedIn = true;
    }
  }

  onSubmit(): void {
    const {username, password} = this.form;

    this.authService.login(username, password).subscribe({
      next: data => {
        storage.setItem('App/session', {user: 'some-user-id', token: 'abc'});
        this.isLoginFailed = false;
        this.authService.isLoggedIn$.next(true);
        this.reloadPage();
      },
      error: err => {
        this.errorMessage = err.error.message;
        this.isLoginFailed = true;
      }
    });
  }

  reloadPage(): void {
    window.location.reload();
  }
}
