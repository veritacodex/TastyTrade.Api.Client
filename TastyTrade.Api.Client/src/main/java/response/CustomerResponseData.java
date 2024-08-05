package response;

import com.fasterxml.jackson.annotation.JsonProperty;

import java.time.LocalDate;
import java.time.OffsetDateTime;

public class CustomerResponseData {
    private String id;
    private String firstName;
    private String lastName;
    private CustomerResponseAddress address;
    private CustomerResponseAddress mailingAddress;
    private String usaCitizenshipType;
    private boolean isForeign;
    private String mobilePhoneNumber;
    private String email;
    private String taxNumberType;
    private LocalDate birthDate;
    private boolean subjectToTaxWithholding;
    private boolean agreedToMargining;
    private boolean hasIndustryAffiliation;
    private boolean hasPoliticalAffiliation;
    private boolean hasListedAffiliation;
    private boolean isProfessional;
    private boolean hasDelayedQuotes;
    private boolean hasPendingOrApprovedApplication;
    private CustomerResponsePermittedAccountType[] permittedAccountTypes;
    private OffsetDateTime createdAt;

    @JsonProperty("id")
    public String getID() {
        return id;
    }

    @JsonProperty("id")
    public void setID(String value) {
        this.id = value;
    }

    @JsonProperty("first-name")
    public String getFirstName() {
        return firstName;
    }

    @JsonProperty("first-name")
    public void setFirstName(String value) {
        this.firstName = value;
    }

    @JsonProperty("last-name")
    public String getLastName() {
        return lastName;
    }

    @JsonProperty("last-name")
    public void setLastName(String value) {
        this.lastName = value;
    }

    @JsonProperty("address")
    public CustomerResponseAddress getAddress() {
        return address;
    }

    @JsonProperty("address")
    public void setAddress(CustomerResponseAddress value) {
        this.address = value;
    }

    @JsonProperty("mailing-address")
    public CustomerResponseAddress getMailingAddress() {
        return mailingAddress;
    }

    @JsonProperty("mailing-address")
    public void setMailingAddress(CustomerResponseAddress value) {
        this.mailingAddress = value;
    }

    @JsonProperty("usa-citizenship-type")
    public String getUsaCitizenshipType() {
        return usaCitizenshipType;
    }

    @JsonProperty("usa-citizenship-type")
    public void setUsaCitizenshipType(String value) {
        this.usaCitizenshipType = value;
    }

    @JsonProperty("is-foreign")
    public boolean getIsForeign() {
        return isForeign;
    }

    @JsonProperty("is-foreign")
    public void setIsForeign(boolean value) {
        this.isForeign = value;
    }

    @JsonProperty("mobile-phone-number")
    public String getMobilePhoneNumber() {
        return mobilePhoneNumber;
    }

    @JsonProperty("mobile-phone-number")
    public void setMobilePhoneNumber(String value) {
        this.mobilePhoneNumber = value;
    }

    @JsonProperty("email")
    public String getEmail() {
        return email;
    }

    @JsonProperty("email")
    public void setEmail(String value) {
        this.email = value;
    }

    @JsonProperty("tax-number-type")
    public String getTaxNumberType() {
        return taxNumberType;
    }

    @JsonProperty("tax-number-type")
    public void setTaxNumberType(String value) {
        this.taxNumberType = value;
    }

    @JsonProperty("birth-date")
    public LocalDate getBirthDate() {
        return birthDate;
    }

    @JsonProperty("birth-date")
    public void setBirthDate(LocalDate value) {
        this.birthDate = value;
    }

    @JsonProperty("subject-to-tax-withholding")
    public boolean getSubjectToTaxWithholding() {
        return subjectToTaxWithholding;
    }

    @JsonProperty("subject-to-tax-withholding")
    public void setSubjectToTaxWithholding(boolean value) {
        this.subjectToTaxWithholding = value;
    }

    @JsonProperty("agreed-to-margining")
    public boolean getAgreedToMargining() {
        return agreedToMargining;
    }

    @JsonProperty("agreed-to-margining")
    public void setAgreedToMargining(boolean value) {
        this.agreedToMargining = value;
    }

    @JsonProperty("has-industry-affiliation")
    public boolean getHasIndustryAffiliation() {
        return hasIndustryAffiliation;
    }

    @JsonProperty("has-industry-affiliation")
    public void setHasIndustryAffiliation(boolean value) {
        this.hasIndustryAffiliation = value;
    }

    @JsonProperty("has-political-affiliation")
    public boolean getHasPoliticalAffiliation() {
        return hasPoliticalAffiliation;
    }

    @JsonProperty("has-political-affiliation")
    public void setHasPoliticalAffiliation(boolean value) {
        this.hasPoliticalAffiliation = value;
    }

    @JsonProperty("has-listed-affiliation")
    public boolean getHasListedAffiliation() {
        return hasListedAffiliation;
    }

    @JsonProperty("has-listed-affiliation")
    public void setHasListedAffiliation(boolean value) {
        this.hasListedAffiliation = value;
    }

    @JsonProperty("is-professional")
    public boolean getIsProfessional() {
        return isProfessional;
    }

    @JsonProperty("is-professional")
    public void setIsProfessional(boolean value) {
        this.isProfessional = value;
    }

    @JsonProperty("has-delayed-quotes")
    public boolean getHasDelayedQuotes() {
        return hasDelayedQuotes;
    }

    @JsonProperty("has-delayed-quotes")
    public void setHasDelayedQuotes(boolean value) {
        this.hasDelayedQuotes = value;
    }

    @JsonProperty("has-pending-or-approved-application")
    public boolean getHasPendingOrApprovedApplication() {
        return hasPendingOrApprovedApplication;
    }

    @JsonProperty("has-pending-or-approved-application")
    public void setHasPendingOrApprovedApplication(boolean value) {
        this.hasPendingOrApprovedApplication = value;
    }

    @JsonProperty("permitted-account-types")
    public CustomerResponsePermittedAccountType[] getPermittedAccountTypes() {
        return permittedAccountTypes;
    }

    @JsonProperty("permitted-account-types")
    public void setPermittedAccountTypes(CustomerResponsePermittedAccountType[] value) {
        this.permittedAccountTypes = value;
    }

    @JsonProperty("created-at")
    public OffsetDateTime getCreatedAt() {
        return createdAt;
    }

    @JsonProperty("created-at")
    public void setCreatedAt(OffsetDateTime value) {
        this.createdAt = value;
    }
}
