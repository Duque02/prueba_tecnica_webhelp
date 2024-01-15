const axios = require('axios');

exports.handler = async function(context, event, callback) {

  const apiKey = process.env.ApiKey;
  const api = process.env.API;
  const patientId = event.PatientCodeSchedule;
  const appointmentId = event.AppointmentId;

  const endpoint = `${api}/api/Appointment`;

 const requestBody = {
    "patientCode" : patientId,
    "appointmentId" : appointmentId
  };
  try{
    axios.defaults.headers = { "ApiKey": apiKey }

      const response = await axios.put(endpoint, requestBody)
      const responseBody = response.data;

      let appointmentSchedule = "";

      appointmentSchedule = `Su cita quedo agendada para el día ... ${responseBody.date} ... a la hora ${responseBody.hours}... gracias por agendar`

  return callback(null, {appointmentSchedule});
  }
  catch (error) {
    return callback(error)
  }
};