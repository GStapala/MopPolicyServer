//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v14.0.0.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0)) (http://NSwag.org)
// </auto-generated>
//----------------------

/* tslint:disable */
/* eslint-disable */
// ReSharper disable InconsistentNaming

import {mergeMap as _observableMergeMap, catchError as _observableCatch} from 'rxjs/operators';
import {Observable, throwError as _observableThrow, of as _observableOf} from 'rxjs';
import {Injectable, Inject, Optional, InjectionToken} from '@angular/core';
import {HttpClient, HttpHeaders, HttpResponse, HttpResponseBase} from '@angular/common/http';
import {PaginatedListOfTodoItemBriefDto, SwaggerException, WeatherForecast} from "./web-api-client";

export const API_BASE_URL = new InjectionToken<string>('API_BASE_URL');

export interface IPolicyClient {
  getPoliciesWithPagination(listId: number, pageNumber: number, pageSize: number): Observable<PaginatedListOfPolicyDto>;
}

@Injectable({
  providedIn: 'root'
})
export class PolicyClient implements IPolicyClient {
  private http: HttpClient;
  private baseUrl: string;
  protected jsonParseReviver: ((key: string, value: any) => any) | undefined = undefined;

  constructor(@Inject(HttpClient) http: HttpClient, @Optional() @Inject(API_BASE_URL) baseUrl?: string) {
    this.http = http;
    this.baseUrl = baseUrl ?? "";
  }

  getPoliciesWithPagination(pageNumber: number = 1, pageSize: number = 10): Observable<PaginatedListOfPolicyDto> {
    let url_ = this.baseUrl + "/api/Policy?";
    if (pageNumber === undefined || pageNumber === null)
      throw new Error("The parameter 'pageNumber' must be defined and cannot be null.");
    else
      url_ += "PageNumber=" + encodeURIComponent("" + pageNumber) + "&";
    if (pageSize === undefined || pageSize === null)
      throw new Error("The parameter 'pageSize' must be defined and cannot be null.");
    else
      url_ += "PageSize=" + encodeURIComponent("" + pageSize) + "&";
    url_ = url_.replace(/[?&]$/, "");

    let options_ : any = {
      observe: "response",
      responseType: "blob",
      headers: new HttpHeaders({
        "Accept": "application/json"
      })
    };

    return this.http.request("get", url_, options_).pipe(_observableMergeMap((response_ : any) => {
      return this.processGetPoliciesWithPagination(response_);
    })).pipe(_observableCatch((response_: any) => {
      if (response_ instanceof HttpResponseBase) {
        try {
          return this.processGetPoliciesWithPagination(response_ as any);
        } catch (e) {
          return _observableThrow(e) as any as Observable<PaginatedListOfTodoItemBriefDto>;
        }
      } else
        return _observableThrow(response_) as any as Observable<PaginatedListOfTodoItemBriefDto>;
    }));
  }

  protected processGetPoliciesWithPagination(response: HttpResponseBase): Observable<PaginatedListOfTodoItemBriefDto> {
    const status = response.status;
    const responseBlob =
      response instanceof HttpResponse ? response.body :
        (response as any).error instanceof Blob ? (response as any).error : undefined;

    let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }}
    if (status === 200) {
      return blobToText(responseBlob).pipe(_observableMergeMap((_responseText: string) => {
        let result200: any = null;
        let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
        result200 = PaginatedListOfTodoItemBriefDto.fromJS(resultData200);
        return _observableOf(result200);
      }));
    } else if (status !== 200 && status !== 204) {
      return blobToText(responseBlob).pipe(_observableMergeMap((_responseText: string) => {
        return throwException("An unexpected server error occurred.", status, _responseText, _headers);
      }));
    }
    return _observableOf(null as any);
  }

}

export class PaginatedListOfPolicyDto implements IPaginatedListOfPolicyDto {
  items?: IPolicyDto[];
  pageNumber?: number;
  totalPages?: number;
  totalCount?: number;
  hasPreviousPage?: boolean;
  hasNextPage?: boolean;
}

export interface IPaginatedListOfPolicyDto {
  items?: IPolicyDto[];
  pageNumber?: number;
  totalPages?: number;
  totalCount?: number;
  hasPreviousPage?: boolean;
  hasNextPage?: boolean;
}

export interface IPolicyDto {
  id?: number;
  Name?: string;
  Description?: string | undefined;
}

export class PolicyDto implements IPolicyDto {
  id?: number;
  Name?: string;
  Description?: string | undefined;
}


function throwException(message: string, status: number, response: string, headers: { [key: string]: any; }, result?: any): Observable<any> {
  if (result !== null && result !== undefined)
    return _observableThrow(result);
  else
    return _observableThrow(new SwaggerException(message, status, response, headers, null));
}

function blobToText(blob: any): Observable<string> {
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
