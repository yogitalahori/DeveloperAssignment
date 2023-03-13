import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { inject, TestBed } from '@angular/core/testing';
import { of } from 'rxjs';
import { ItemsService } from './items.service';

describe('ItemsService', () => {
  let service: ItemsService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [ItemsService, { provide: 'BASE_URL', useValue: '' }]
    });
    service = TestBed.inject(ItemsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should get users', () => {
    inject(
      [HttpTestingController, ItemsService],
      async (httpMock: HttpTestingController, itemsService: ItemsService) => {
        const mockItems = [
          { itemId: 1, name: 'TV', value: 200 },
          { itemId: 2, name: 'Jeans', value: 500 }
        ];

        //itemsService.getCustomerItems().subscribe((result) => {
        //  //expect(result).toEqual(mockItems);
        //  spyOn(itemsService, 'getCustomerItems').and.returnValue(of(result));
        //});

        var items = await itemsService.getCustomerItems().toPromise();
        spyOn(itemsService, 'getCustomerItems').and.returnValue(of(items!));
        //expect(of(items!)).toEqual(mockItems);
        httpMock.verify();
      }
    )
  });
});
