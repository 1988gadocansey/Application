import {HttpClient, HttpEvent, HttpHeaders, HttpResponse, HttpResponseBase} from '@angular/common/http';
import {Injectable, inject, Inject, Optional} from '@angular/core';
import { User } from '../models/user.model';
import {DashboardModel, DashboardViewModel } from "../models/dashboard.model";

import { mergeMap as _observableMergeMap, catchError as _observableCatch } from 'rxjs/operators';
import { Observable, throwError as _observableThrow, of as _observableOf } from 'rxjs';
@Injectable({
  providedIn: 'root',
})
export class HttpService {
  apiUrl = 'https://localhost:5001/api';
  http = inject(HttpClient);
  protected jsonParseReviver: ((key: string, value: any) => any) | undefined = undefined;

  token: string|any = localStorage.getItem('token');
  constructor() {}

  getAllEmployee() {
    console.log('getAllEmployee', localStorage.getItem('token'));
    return this.http.get<User[]>(this.apiUrl + '/api/Employee');
  }
  createEmployee(employee: User) {
    return this.http.post(this.apiUrl + '/api/Employee', employee);
  }
  getEmployee(employeeId: number) {
    return this.http.get<User>(
      this.apiUrl + '/api/Employee/' + employeeId
    );
  }
  updateEmployee(employeeId: number, employee: User) {
    return this.http.put<User>(
      this.apiUrl + '/api/Employee/' + employeeId,
      employee
    );
  }
  deleteEmployee(employeeId: number) {
    return this.http.delete(this.apiUrl + '/api/Employee/' + employeeId);
  }
  login(email: string, password: string) {
    return this.http.post<{ accessToken: string }>(this.apiUrl + '/Users/login', {
      email: email,
      password: password,
    });
  }
  googleLogin(idToken: string) {
    return this.http.post<{ token: string }>(
      this.apiUrl + '/api/Auth/google-login',
      {
        idToken: idToken,
      }
    );
  }

}

export class SwaggerException extends Error {
  override message: string;
  status: number;
  response: string;
  headers: { [key: string]: any; };
  result: any;

  constructor(message: string, status: number, response: string, headers: { [key: string]: any; }, result: any) {
    super();

    this.message = message;
    this.status = status;
    this.response = response;
    this.headers = headers;
    this.result = result;
  }

  protected isSwaggerException = true;

  static isSwaggerException(obj: any): obj is SwaggerException {
    return obj.isSwaggerException === true;
  }

}
interface IDashboardModel{
  get(): Observable<DashboardViewModel>;
}
@Injectable({
  providedIn: 'root'
})
export class DashboardData implements  IDashboardModel{
  private http: HttpClient;
  private baseUrl="https://localhost:5001/api";
  private  token =  localStorage.getItem('accessToken');

  protected jsonParseReviver: ((key: string, value: any) => any) | undefined = undefined;
  constructor(@Inject(HttpClient) http: HttpClient) {
    this.http = http;

  }


  get(): Observable<DashboardViewModel> {

    let options_ : any = {
      observe: "response",
      responseType: "blob",

      token:this.token,
      headers: new HttpHeaders({
        "Accept": "application/json"
      })
    };

    // return this.http.request<IUserViewModel>("get",  this.apiUrl + '/Dashboard',options_);
    return this.http.request("get", this.baseUrl + '/Dashboard', options_).pipe(_observableMergeMap((response_ : any) => {
      return this.processGet(response_);
    })).pipe(_observableCatch((response_: any) => {
      if (response_ instanceof HttpResponseBase) {
        try {
          return this.processGet(response_ as any);
        } catch (e) {
          return _observableThrow(e) as any as Observable<DashboardViewModel>;
        }
      } else
        return _observableThrow(response_) as any as Observable<DashboardViewModel>;
    }));

  }
  protected processGet(response: HttpResponseBase): Observable<DashboardViewModel> {
    const status = response.status;
    const responseBlob =
      response instanceof HttpResponse ? response.body :
        (response as any).error instanceof Blob ? (response as any).error : undefined;

    let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }}
    if (status === 200) {
      return this.blobToText(responseBlob).pipe(_observableMergeMap((_responseText: string) => {
        let result200: any = null;
        let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
        result200 = DashboardModel.fromJS(resultData200);
        return _observableOf(result200);
      }));
    } else if (status !== 200 && status !== 204) {
      return this.blobToText(responseBlob).pipe(_observableMergeMap((_responseText: string) => {
        return this.throwException("An unexpected server error occurred.", status, _responseText, _headers);
      }));
    }
    return _observableOf(null as any);
  }
  blobToText(blob: any): Observable<string> {
    return new Observable<string>((observer: any) => {
      if (!blob) {
        observer.next("");
        observer.complete();
      } else {
        let reader = new FileReader();
        reader.onload = event => {
          observer.next((event.target as any).result);
          observer.complete();
        };
        reader.readAsText(blob);
      }
    });
  }
  throwException(message: string, status: number, response: string, headers: { [key: string]: any; }, result?: any): Observable<any> {
    if (result !== null && result !== undefined)
      return _observableThrow(result);
    else
      return _observableThrow(new SwaggerException(message, status, response, headers, null));
  }
}
