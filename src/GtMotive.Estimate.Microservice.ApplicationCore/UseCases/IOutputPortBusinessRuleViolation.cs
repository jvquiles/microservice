namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases
{
    /// <summary>
    /// Interface to define the Business Rule Violation Output Port.
    /// </summary>
    public interface IOutputPortBusinessRuleViolation
    {
        /// <summary>
        /// Informs a business rule was violated.
        /// </summary>
        /// <param name="message">Text description.</param>
        void BusinessRuleViolationHandle(string message);
    }
}
