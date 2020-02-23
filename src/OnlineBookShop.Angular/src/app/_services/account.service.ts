import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserForLoginDto } from '../_models/Account/UserForLoginDto';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { BearerTokenDto } from '../_models/Account/BearerTokenDto';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  baseUrl = environment.apiUrl + 'account/';

  constructor(private http: HttpClient) { }

  isLoggedIn(): boolean{
    const token = localStorage.getItem('accessToken');
    return token ? true : false;
  }

  login(userForLoginDto: UserForLoginDto): Observable<BearerTokenDto> {
    return this.http.post<BearerTokenDto>(this.baseUrl + 'login/', userForLoginDto);
  }
}
