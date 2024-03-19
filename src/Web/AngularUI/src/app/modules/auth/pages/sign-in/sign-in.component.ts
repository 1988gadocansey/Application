import {Component, inject, OnInit} from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { NgClass, NgIf } from '@angular/common';
import { AngularSvgIconModule } from 'angular-svg-icon';
import {HttpService} from "../../../../core/services/HttpService";
import {Store} from "@ngrx/store";

import * as UserActions from "../../../../core/stores/user/user.actions";
import {ToastrService} from "ngx-toastr";
import {AuthorizeService} from "../../../../core/services/authorize.service";
import {NgxLoadingModule} from "ngx-loading";

@Component({
    selector: 'app-sign-in',
    templateUrl: './sign-in.component.html',
    styleUrls: ['./sign-in.component.scss'],
    standalone: true,
  imports: [
    FormsModule,
    ReactiveFormsModule,
    RouterLink,
    AngularSvgIconModule,
    NgClass,
    NgIf,
    NgxLoadingModule,

  ],
})
export class SignInComponent implements OnInit {
  builder = inject(FormBuilder);
  httpService = inject(AuthorizeService);
  router = inject(Router);
  form!: FormGroup;
  submitted = false;
  passwordTextType!: boolean;
  error: Boolean = false;
  loading: boolean = false;

  constructor(private readonly _formBuilder: FormBuilder, private readonly _router: Router,private toastr: ToastrService,private store:Store) {}

  ngOnInit(): void {
    this.form = this._formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required],
    });
  }

  get f() {
    return this.form.controls;
  }

  togglePasswordTextType() {
    this.passwordTextType = !this.passwordTextType;
  }

  onSubmit() {
    this.submitted = true;
    const { email, password } = this.form.value;
  }
  onLogin() {
    this.loading = true;
    this.submitted = true;
    const email = this.form.value.email!;
    const password = this.form.value.password!;
    // stop here if form is invalid
    if (this.form.invalid) {
      return;
    }
    this.httpService.login(email, password).subscribe(
      (result) => {
        this.loading = false;
        console.log(result);
        localStorage.setItem('token', result.accessToken);

        // update user store then redirect to homepage
        // Dispatch the setUser action to update the user state in the store

        //this.store.dispatch(UserActions.setUsers({users:  this.httpService.getUserInfo() }));

         // this.toastr.success('Hello world!', 'Toastr fun!');

        this._router.navigate(['dashboard']);
        // update user store
      },
      (error) => {
        console.error('An error occurred during login:', error);
        this.loading = false,
        this.error = true; // Set error flag for displaying error message in the template
      }
    );


  }
}
