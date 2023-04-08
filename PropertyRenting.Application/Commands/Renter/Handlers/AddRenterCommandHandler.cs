namespace PropertyRenting.Application.Commands.Renter.Handlers;

public class AddRenterCommandHandler : IRequestHandler<AddRenterCommand, ErrorOr<bool>>
{
    private readonly IRenterRepository _renterRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddRenterCommandHandler(IRenterRepository renterRepository, IUnitOfWork unitOfWork)
    {
        _renterRepository = renterRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<bool>> Handle(AddRenterCommand request, CancellationToken cancellationToken)
    {
        var renterType = RenterType.FromValue(request.RenterType);
        var renterName = RenterName.Create(request.Name);
        var nationalityId = EntityId.Create(request.NationalityId);
        var renterIdentity = MemberIdentity.Create(request.IdentityType, request.IdentityNumber, request.IdentityIssuePlace, request.IdentityExpiryDate);
        var cityId = EntityId.Create(request.CityId);
        var email = EmailAddress.Create(request.Email);
        var phoneNumber = PhoneNumber.Create(request.PhoneNumber);
        var otherPhoneNumber = PhoneNumber.Create(request.OtherPhoneNumber);
        var mobileNumber = MobileNumber.Create(request.MobileNumber);
        var otherMobileNumber = MobileNumber.Create(request.OtherMobileNumber);
        var guarantorMobileNumber = MobileNumber.Create(request.GuarantorMobileNumber);
        var gender = Gender.FromValue(request.Gender);

        var contactPeople = request.ContactPeople.Select(contactPerson => new
        {
            Name = ContactPersonName.Create(contactPerson.Name),
            PhoneNumber = PhoneNumber.Create(contactPerson.PhoneNumber),
            MobileNumber = MobileNumber.Create(contactPerson.MobileNumber),
            Email = EmailAddress.Create(contactPerson.Email),
            Identity = MemberIdentity.Create(contactPerson.IdentityType, contactPerson.IdentityNumber, contactPerson.IdentityIssuePlace, contactPerson.IdentityExpiryDate),
            contactPerson.BirthDate,
            contactPerson.Notes
        });

        var inInvalid = ValidatorBuilder.Init().Append(renterType, Domain.Errors.Errors.Renter.InvalidRenterType).Append(renterName).Append(nationalityId)
            .Append(renterIdentity).Append(cityId).Append(email).Append(phoneNumber).Append(otherPhoneNumber).Append(mobileNumber).Append(otherMobileNumber)
            .Append(guarantorMobileNumber).Append(gender, Domain.Errors.Errors.Renter.InvalidGender)
            .Append(contactPeople.SelectMany(x => new List<ErrorOr<object>>()
            {
                x.Name,
                x.PhoneNumber,
                x.Identity
            })
            .Select(contactPerson => contactPerson).ToList())
            .IsInValid(out List<Error> ErrorList);


        if (inInvalid) return ErrorList;

        var renter = Domain.Aggregates.Renter.Create(request.IsActive, renterType, renterName.Value,
            nationalityId.Value, renterIdentity.Value, request.BirthDate, cityId.Value, request.RegionCode,
            request.PostalCode, email.Value, phoneNumber.Value, otherPhoneNumber.Value, mobileNumber.Value,
            otherMobileNumber.Value, request.Fax, request.GuarantorName, guarantorMobileNumber.Value,
            request.GuarantorAddress, gender, request.Notes);

        foreach (var contactPerson in contactPeople)
        {
            renter.AddContactPerson(contactPerson.Name.Value, contactPerson.PhoneNumber.Value,
                contactPerson.MobileNumber.Value, contactPerson.Email.Value, contactPerson.Identity.Value, contactPerson.BirthDate, contactPerson.Notes);
        }


        _renterRepository.Create(renter);

        return await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
