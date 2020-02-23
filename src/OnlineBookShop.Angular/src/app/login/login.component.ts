import { Component, OnInit } from '@angular/core';
import { UserForLoginDto } from '../_models/Account/UserForLoginDto';
import { AccountService } from '../_services/account.service';
import { BearerTokenDto } from '../_models/Account/BearerTokenDto';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  private returnUrl: string;

  public userLoginDto: UserForLoginDto;
  public userLoginForm: FormGroup;

  constructor(private accountService: AccountService,
              private router: Router,
              private route: ActivatedRoute,
              private formBuilder: FormBuilder
    ) { }

  ngOnInit() {
    this.userLoginForm = this.formBuilder.group({
      userName: ['', [Validators.required]],
      password: ['', [Validators.required]]
    });

    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/admin';

  }

  login() {
    const userLogin = Object.assign({}, this.userLoginDto, this.userLoginForm.value);

    this.accountService.login(userLogin)
      .subscribe((bearerToken: BearerTokenDto) => {
        localStorage.setItem('accessToken', bearerToken.accessToken);
        this.router.navigate([this.returnUrl]);
      });

  }

}
