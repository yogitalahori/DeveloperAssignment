import { HttpClientTestingModule } from '@angular/common/http/testing';
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { ItemsService } from '../items.service';
import { ItemsComponent } from './items.component';

describe('ItemsComponent', () => {
  let component: ItemsComponent;
  let fixture: ComponentFixture<ItemsComponent>;
  let itemService: ItemsService;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      declarations: [ItemsComponent],
      providers: [ItemsService, { provide: 'BASE_URL', useValue: '' }]
    })
      .compileComponents();
     itemService = TestBed.inject(ItemsService);
  });

  //beforeEach(() => {
  //  fixture = TestBed.createComponent(ItemsComponent);
  //  component = fixture.componentInstance;
  //  //httpClient = TestBed.inject(HttpClient);
  //  //httpTestingController = TestBed.inject(HttpTestingController);
  //  itemService = TestBed.inject(ItemsService);
  //  fixture.detectChanges();
  //});

  it('should create the app', async(() => {
    const fixture = TestBed.createComponent(ItemsComponent);
    const app = fixture.debugElement.componentInstance;
    expect(app).toBeTruthy();
  }));

  it('should render title in a h2 tag', async(() => {
    const fixture = TestBed.createComponent(ItemsComponent);
    fixture.detectChanges();
    const compiled = fixture.debugElement.nativeElement;
    expect(compiled.querySelector('h2').textContent).toContain('Customer Items');
  }));

});
