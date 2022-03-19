import {
  Box,
  Alert,
  AlertIcon,
  AlertDialog,
  AlertDescription,
} from "@chakra-ui/react";
import React from "react";

const ErrorMessage = ({ message }) => {
  return (
    <>
      <Box my={4}>
        <Alert status="error" borderRadius={4}>
          <AlertIcon />
          <AlertDescription maxWidth="100">{message}</AlertDescription>
        </Alert>
      </Box>
    </>
  );
};

export default ErrorMessage;
