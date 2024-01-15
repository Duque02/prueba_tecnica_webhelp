const axios = require('axios');

exports.handler = async function(context, event, callback) {
  
  const apiKey = process.env.ApiKey;
  const api = process.env.API;
  const patientId = event.patientCode;

  if (!patientId) {
    const error = new Error("Invalid patient code");
    return callback(error);
  }

  const endpoint = `${api}/api/Patient/${patientId}`;

  try {
      axios.defaults.headers = { "ApiKey": apiKey }

      const response = await axios.get(endpoint)
      const responseBody = response.data;

      const result = { 
        exists: true,
        name: `${responseBody.name} ... ${responseBody.lastName}`
      };

      return callback(null, result);      
  } catch (error) {
    const statusCode = error.response?.status ?? 0;

    if (statusCode == 404) {
      return callback(null, { exists: false, name: "" });
    }

    return callback(error)
  }
};