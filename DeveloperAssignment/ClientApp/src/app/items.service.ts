import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ItemsService {
  public url!: string;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.url = baseUrl + 'items';
  }

  getCustomerItems(): Observable<any[]> {
    return this.http.get<any[]>(this.url + '/getItems');
  }

  deleteItem(itemId: number): Observable<any> {
    return this.http.delete(this.url + '?id=' + itemId, {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    });
  }

  addItem(item: {}) {
    return this.http.post<any>(this.url + '/addItem', JSON.stringify(item), {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    });
  }
}
